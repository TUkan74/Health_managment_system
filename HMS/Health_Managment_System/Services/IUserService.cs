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
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
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
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            //TODO: Implement this
            throw new NotImplementedException();
        }

        public Task<User> GetUserByNameAsync(string username)
        {
            //TODO: Implement this
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            //TODO: Implement this
            throw new NotImplementedException();
        }
    }



}
