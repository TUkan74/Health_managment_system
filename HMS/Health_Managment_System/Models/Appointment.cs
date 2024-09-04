using System;

namespace HealthcareManagementSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Link to the patient
        public int DoctorId { get; set; } // Link to the doctor
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Status of the appointment (e.g., Scheduled, Completed, Cancelled)
    }
}
