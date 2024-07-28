using System;

namespace HealthcareManagementSystem.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientRecordId { get; set; }
        public string DrugName { get; set; }
        public string Dosage { get; set; }
        public string UsageInstructions { get; set; }
        public DateTime DatePrescribed { get; set; }
    }
}
