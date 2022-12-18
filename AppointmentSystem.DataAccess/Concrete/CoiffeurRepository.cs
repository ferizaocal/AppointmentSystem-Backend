using System;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.DataAccess.Concrete
{
    public class CoiffeurRepository : GenericRepository<Coiffeur>, ICoiffeurRepository
    {
        public CoiffeurRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}

