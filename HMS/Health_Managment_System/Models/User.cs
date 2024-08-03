namespace HealthcareManagementSystem.Models
{
    // Models/User.cs
    public class User
    {
        public int Id { get; set; }  // Auto-generated primary key
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public int? PatientRecordId { get; set; }  // Foreign key to PatientRecord
        public PatientRecord PatientRecord { get; set; }  // Navigation property
    }

}
