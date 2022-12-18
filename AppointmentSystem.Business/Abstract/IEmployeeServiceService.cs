using System;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Abstract
{
    public interface IEmployeeServiceService : IService<EmployeeService>, IPagination<EmployeeService>
    {

    }
}

