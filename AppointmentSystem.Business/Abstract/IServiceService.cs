using System;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Abstract
{
    public interface IServiceService : IService<Service>, IPagination<Service>
    {

    }
}

