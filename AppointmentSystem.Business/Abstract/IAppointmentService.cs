using System;
using System.Collections.Generic;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Abstract
{
    public interface IAppointmentService : IService<Appointment>, IPagination<Appointment>
    {
        ServiceResponse<Appointment> add(Appointment appointment, List<AppointmentService> appointmentService);
    }
}

