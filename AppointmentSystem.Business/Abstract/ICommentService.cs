using System;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Abstract
{
    public interface ICommentService : IService<Comment>, IPagination<Comment>
    {
    }
}

