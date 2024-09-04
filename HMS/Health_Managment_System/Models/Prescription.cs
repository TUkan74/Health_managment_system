using System;

namespace HealthcareManagementSystem.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientRecordId { get; set; }  // Link to the patient's record
        public int DoctorId { get; set; }  // Link to the doctor who prescribed it
        public string DrugName { get; set; }
        public string Dosage { get; set; }
        public string UsageInstructions { get; set; }
        public DateTime DatePrescribed { get; set; }

        // Navigation properties
        public PatientRecord PatientRecord { get; set; }  // Patient details
        public User Doctor { get; set; }  // Doctor details
    }
}
