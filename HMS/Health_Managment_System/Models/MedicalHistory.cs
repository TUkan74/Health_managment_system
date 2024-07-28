using System;

namespace HealthcareManagementSystem.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public int PatientRecordId { get; set; }
        public string Condition { get; set; }
        public string Treatment { get; set; }
        public DateTime DateDiagnosed { get; set; }
    }
}
