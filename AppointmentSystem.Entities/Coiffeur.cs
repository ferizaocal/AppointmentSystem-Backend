using System;
namespace AppointmentSystem.Entities
{
	public class Coiffeur:BaseEntity
    {
		public string CoiffeurName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string CoiffeurImageSrc { get; set; }
		public string About { get; set; }
		public string Description { get; set; }
		public string Keywords { get; set; }
		public string Adress { get; set; }
		public string Phone { get; set; }
		public string AdressMap { get; set; }
	}
}

