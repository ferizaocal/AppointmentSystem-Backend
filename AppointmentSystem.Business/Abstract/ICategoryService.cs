using System;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Abstract
{
    public interface ICategoryService : IService<Category>, IPagination<Category>
    {
    }
}

