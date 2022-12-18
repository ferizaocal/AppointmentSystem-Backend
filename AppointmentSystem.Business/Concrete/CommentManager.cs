using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        public CommentManager(ICommentRepository comment)
        {
            commentRepository = comment;
        }

        public ServiceResponse<Comment> add(Comment entity)
        {
            var response = new ServiceResponse<Comment>();
            try
            {
                response.Entity = commentRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Comment> delete(Expression<Func<Comment, bool>> expression)
        {
            var response = new ServiceResponse<Comment>();
            try
            {
                response.IsSuccessful = commentRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Comment> get(Expression<Func<Comment, bool>> expression)
        {
            var response = new ServiceResponse<Comment>();
            try
            {
                response.Entity = commentRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Comment> getList()
        {
            var response = new ServiceResponse<Comment>();
            try
            {
                response.Count = commentRepository.Count();
                response.List = commentRepository.GetAll().ToList();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Comment> getList(Expression<Func<Comment, bool>> expression)
        {
            var response = new ServiceResponse<Comment>();
            try
            {
                var list = commentRepository.Table.Where(expression).ToList();
                response.List = list;
                response.Count = list.Count;
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public PaginedResponse<Comment> pagination(Expression<Comment> expression, int pageNo, int showCount)
        {
            var response = new PaginedResponse<Comment>();
            try
            {
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Comment> update(Comment entity)
        {
            var response = new ServiceResponse<Comment>();
            try
            {
                response.Entity = commentRepository.Update(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }
    }
}

