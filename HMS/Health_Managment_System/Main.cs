using Health_Managment_System.Forms;
using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
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

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<LoginForm>();
            services.AddScoped<RegistrationForm>();
            services.AddDbContext<ApplicationDbContext>();
            // Add other services and forms as needed
        }
    }
}