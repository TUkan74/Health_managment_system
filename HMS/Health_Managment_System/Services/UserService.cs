using HealthcareManagementSystem.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Managment_System.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly object _lock = new object();
        //private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1); 


        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// User managment methods
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            lock (_lock)
            {
                var user = _context.Users
                    .Include(u => u.PatientRecord)  // Include the PatientRecord
                    .SingleOrDefaultAsync(u => u.Username == username).Result;

                if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    return null;
                }

                return user;
            }
        }

        /*
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            await _semaphore.WaitAsync();
            try
            {
                var user = await _context.Users
                    .Include(u => u.PatientRecord)
                    .SingleOrDefaultAsync(u => u.Username == username);

                if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    return null;
                }

                return user;
            }
            finally
            {
                _semaphore.Release();
            }
        }*/

        public async Task RegisterAsync(User user)
        {
            lock (_lock)
            {
                if (_context.Users.Any(u => u.Username == user.Username))
                {
                    throw new Exception("Username is already taken.");
                }

                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    throw new Exception("Email is already registered.");
                }

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

                // Add the PatientRecord
                if (user.PatientRecord != null)
                {
                    _context.PatientRecords.Add(user.PatientRecord);
                }

                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            lock (_lock)
            {
                return _context.Users
                    .Include(u => u.PatientRecord)  // Include the PatientRecord
                    .ToList();
            }
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            lock (_lock)
            {
                return _context.Roles.ToList();
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            lock (_lock)
            {
                return _context.Users
                    .Include(u => u.PatientRecord)  // Include the PatientRecord
                    .SingleOrDefault(u => u.Id == id);
            }
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            lock (_lock)
            {
                return _context.Users
                    .Include(u => u.PatientRecord)  // Include the PatientRecord
                    .SingleOrDefault(u => u.Username == username);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            lock (_lock)
            {
                var user = _context.Users.Find(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            lock (_lock)
            {
                var existingUser = _context.Users
                    .Include(u => u.PatientRecord)
                    .FirstOrDefault(u => u.Id == user.Id);

                if (existingUser == null)
                {
                    throw new Exception("User not found.");
                }

                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.Role = user.Role;
                existingUser.PasswordHash = user.PasswordHash;

                if (existingUser.PatientRecord != null && user.PatientRecord != null)
                {
                    existingUser.PatientRecord.FirstName = user.PatientRecord.FirstName;
                    existingUser.PatientRecord.LastName = user.PatientRecord.LastName;
                    existingUser.PatientRecord.DateOfBirth = user.PatientRecord.DateOfBirth;
                    existingUser.PatientRecord.Address = user.PatientRecord.Address;
                    existingUser.PatientRecord.PhoneNumber = user.PatientRecord.PhoneNumber;
                    existingUser.PatientRecord.Email = user.PatientRecord.Email;
                }
                else if (user.PatientRecord != null)
                {
                    existingUser.PatientRecord = user.PatientRecord;
                }

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// User appointment methods
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        public async Task<List<Appointment>> GetAppointmentsByUserAsync(int userId, string role)
        {
            if (role == "Patient")
            {
                // Retrieve appointments for the patient
                return await _context.Appointments.Where(a => a.UserId == userId).ToListAsync();
            }
            else if (role == "Doctor")
            {
                // Retrieve appointments for the doctor
                return await _context.Appointments.Where(a => a.DoctorId == userId).ToListAsync();
            }

            return new List<Appointment>();
        }


        public async Task AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Medical History methods
        /// </summary>
        /// <param name="patientRecordId">The ID of the patient record.</param>
        /// <returns>A list of medical histories associated with the patient.</returns>
        public async Task<List<MedicalHistory>> GetMedicalHistoriesByPatientIdAsync(int patientRecordId)
        {
            lock (_lock)
            {
                return _context.MedicalHistories
                    .Where(m => m.PatientRecordId == patientRecordId)
                    .ToList();
            }
        }


        public async Task AddMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            lock (_lock)
            {
                _context.MedicalHistories.Add(medicalHistory);
                _context.SaveChanges();
            }
        }


        public async Task UpdateMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            lock (_lock)
            {
                var existingHistory = _context.MedicalHistories
                    .FirstOrDefault(m => m.Id == medicalHistory.Id);

                if (existingHistory == null)
                {
                    throw new Exception("Medical history record not found.");
                }

                existingHistory.Condition = medicalHistory.Condition;
                existingHistory.Treatment = medicalHistory.Treatment;
                existingHistory.DateDiagnosed = medicalHistory.DateDiagnosed;

                _context.SaveChanges();
            }
        }

        public async Task DeleteMedicalHistoryAsync(int id)
        {
            lock (_lock)
            {
                var medicalHistory = _context.MedicalHistories.Find(id);
                if (medicalHistory != null)
                {
                    _context.MedicalHistories.Remove(medicalHistory);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Medical history record not found.");
                }
            }
        }

        /// <summary>
        /// Retrieves all prescriptions for a given patient record.
        /// </summary>
        /// <param name="patientRecordId">The ID of the patient record.</param>
        /// <returns>A list of prescriptions associated with the patient.</returns>
        public async Task<List<Prescription>> GetPrescriptionsByPatientIdAsync(int patientRecordId)
        {
            lock (_lock)
            {
                return _context.Prescriptions
                    .Include(p => p.Doctor)
                    .Where(p => p.PatientRecordId == patientRecordId)
                    .ToList();
            }
        }

        public async Task AddPrescriptionAsync(Prescription prescription)
        {
            lock (_lock)
            {
                _context.Prescriptions.Add(prescription);
                _context.SaveChanges();
            }
        }

        public async Task UpdatePrescriptionAsync(Prescription prescription)
        {
            lock (_lock)
            {
                var existingPrescription = _context.Prescriptions
                    .FirstOrDefault(p => p.Id == prescription.Id);

                if (existingPrescription == null)
                {
                    throw new Exception("Prescription not found.");
                }

                existingPrescription.DrugName = prescription.DrugName;
                existingPrescription.Dosage = prescription.Dosage;
                existingPrescription.UsageInstructions = prescription.UsageInstructions;
                existingPrescription.DatePrescribed = prescription.DatePrescribed;
                existingPrescription.DoctorId = prescription.DoctorId;

                _context.SaveChanges();
            }
        }

        
        public async Task DeletePrescriptionAsync(int id)
        {
            lock (_lock)
            {
                var prescription = _context.Prescriptions.Find(id);
                if (prescription != null)
                {
                    _context.Prescriptions.Remove(prescription);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Prescription not found.");
                }
            }
        }


    }




}
