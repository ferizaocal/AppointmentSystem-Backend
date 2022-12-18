using System;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.DataAccess.Concrete
{
    public class WorkingHoursRepository : GenericRepository<WorkingHours>, IWorkingHoursRepository
    {
        public WorkingHoursRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
               
        }
    }
}

