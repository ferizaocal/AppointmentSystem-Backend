using System;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.DataAccess.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
      
        public CategoryRepository(ApplicationDbContext db):base(db)
        {
           
        }

      
    }
}

