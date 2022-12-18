using System;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.DataAccess.Concrete
{
    public class AppointmentServiceRepository : GenericRepository<AppointmentService>, IAppointmentServiceRepository
    {
        public AppointmentServiceRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}

