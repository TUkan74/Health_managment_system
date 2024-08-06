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
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly object _lock = new object();

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }




}
