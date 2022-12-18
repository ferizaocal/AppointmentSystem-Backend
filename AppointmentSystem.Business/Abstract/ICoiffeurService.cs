using System;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Abstract
{
    public interface ICoiffeurService : IService<Coiffeur>
    {
        ServiceResponse<Coiffeur> Authentication(string user, string password);
    }
}

