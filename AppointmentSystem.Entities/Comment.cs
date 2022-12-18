using System;
namespace AppointmentSystem.Entities
{
    public class Comment : BaseEntity
    {
        public int AppointmentID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }
    }
}

