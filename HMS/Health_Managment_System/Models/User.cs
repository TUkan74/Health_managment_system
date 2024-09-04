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
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();

        // FullName property that combines FirstName and LastName from PatientRecord
        public string FullName
        {
            get
            {
                if (PatientRecord != null)
                {
                    return $"{PatientRecord.FirstName} {PatientRecord.LastName}";
                }
                return Username; // Fallback to username if PatientRecord is not available
            }
        }
    }
}
