using System;
namespace AppointmentSystem.Entities
{
	public class AppointmentService:BaseEntity
	{
		public int AppointmentID { get; set; }
		public int ServiceID { get; set; }
		public int EmployeeID { get; set; }

	}
}

