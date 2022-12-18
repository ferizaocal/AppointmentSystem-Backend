using System;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.DataAccess.Concrete
{
    public class GalleryRepository : GenericRepository<Gallery>, IGalleryRepository
    {
        public GalleryRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}

