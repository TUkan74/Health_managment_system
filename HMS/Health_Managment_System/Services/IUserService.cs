using HealthcareManagementSystem.Models;


namespace Health_Managment_System.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
        Task RegisterAsync(User user);
        Task<List<Role>> GetRolesAsync();
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string username);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(User user);
        
        // Appointment methods
        Task<List<Appointment>> GetAppointmentsByUserAsync(int userId,string role);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int appointmentId);

        // Medical history methods
        Task<List<MedicalHistory>> GetMedicalHistoriesByPatientIdAsync(int patientRecordId);
        Task AddMedicalHistoryAsync(MedicalHistory medicalHistory);
        Task UpdateMedicalHistoryAsync(MedicalHistory medicalHistory);
        Task DeleteMedicalHistoryAsync(int id);

        // Prescription methods
        Task<List<Prescription>> GetPrescriptionsByPatientIdAsync(int patientRecordId);
        Task AddPrescriptionAsync(Prescription prescription);
        Task UpdatePrescriptionAsync(Prescription prescription);
        Task DeletePrescriptionAsync(int id);

    }

   




}
