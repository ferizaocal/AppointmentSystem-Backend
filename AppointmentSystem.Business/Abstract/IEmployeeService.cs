using System;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Abstract
{
    public interface IEmployeeService : IService<Employee>, IPagination<Employee>
    {

    }
}

