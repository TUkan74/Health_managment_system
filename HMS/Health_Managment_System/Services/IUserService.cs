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

        public UserService(ApplicationDbContext context)
        {
            _context = context!;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users
                .Include(u => u.PatientRecord)  // Include the PatientRecord
                .SingleOrDefaultAsync(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }

        public async Task RegisterAsync(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            {
                throw new Exception("Username is already taken.");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            // Add the PatientRecord
            if (user.PatientRecord != null)
            {
                _context.PatientRecords.Add(user.PatientRecord);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.PatientRecord)  // Include the PatientRecord
                .ToListAsync();
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.PatientRecord)  // Include the PatientRecord
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.PatientRecord)  // Include the PatientRecord
                .SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users
                .Include(u => u.PatientRecord)
                .FirstOrDefaultAsync(u => u.Id == user.Id);

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

            await _context.SaveChangesAsync();
        }
    }



}
