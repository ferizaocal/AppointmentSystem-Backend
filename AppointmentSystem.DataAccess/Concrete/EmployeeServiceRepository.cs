using System;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.DataAccess.Concrete
{
    public class EmployeeServiceRepository : GenericRepository<EmployeeService>, IEmployeeServiceRepository
    {
        public EmployeeServiceRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}

