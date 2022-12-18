using System;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.DataAccess.Concrete
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}

