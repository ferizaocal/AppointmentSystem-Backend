using System;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.DataAccess.Concrete
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}

