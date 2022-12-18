using System;
namespace AppointmentSystem.Entities
{
    public class Appointment : BaseEntity
    {
        public string AppointmentNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}

