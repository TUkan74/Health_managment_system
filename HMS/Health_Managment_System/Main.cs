using Health_Managment_System.Forms;
using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Health_Managment_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            EnsureAdminUser(serviceProvider).GetAwaiter().GetResult();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
            /*var adminForm = serviceProvider.GetRequiredService<AdminForm>();
            Application.Run(adminForm);*/
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                // This adress should be changed to the adress of the database on your computer
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HealthcareManagementSystem;Trusted_Connection=True;"));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<LoginForm>();
            services.AddScoped<RegistrationForm>();
            services.AddScoped<PatientForm>();  
            services.AddScoped<AdminForm>();
        }

        private static async Task EnsureAdminUser(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

            if (!context.Users.Any(u => u.Username == "administrator"))
            {
                var adminUser = new User
                {
                    Username = "administrator",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"), // Use a strong password in reality
                    Role = "Admin",
                    Email = "admin@asdadmin.com"
                    
                };
                await userService.RegisterAsync(adminUser);
            }
        }
    }
}