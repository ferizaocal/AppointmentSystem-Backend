using System;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Abstract
{
    public interface ICustomerService : IService<Customer>, IPagination<Customer>
    {
    }
}

