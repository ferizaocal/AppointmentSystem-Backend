using System;
namespace AppointmentSystem.Entities
{
    public class WorkingHours : BaseEntity
    {
        public string Day { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
    }
}

