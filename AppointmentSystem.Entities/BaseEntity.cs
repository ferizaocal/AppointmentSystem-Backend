using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentSystem.Entities
{
	public class BaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
	}
}

