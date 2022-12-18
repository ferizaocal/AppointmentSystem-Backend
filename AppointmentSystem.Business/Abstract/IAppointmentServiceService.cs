using System;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Abstract
{
    public interface IAppointmentServiceService : IService<AppointmentService>, IPagination<AppointmentService>
    {
    }
}

