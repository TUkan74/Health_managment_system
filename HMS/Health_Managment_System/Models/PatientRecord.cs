using System;
using System.Collections.Generic;

namespace HealthcareManagementSystem.Models
{
    public class PatientRecord
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //public List<MedicalHistory> MedicalHistories { get; set; }
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    }
}
