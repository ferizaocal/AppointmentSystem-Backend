using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
	public class CategoryManager:ICategoryService
	{
        private readonly ICategoryRepository categoryRepository;
		public CategoryManager(ICategoryRepository category)
		{
            categoryRepository = category;
		}

        public ServiceResponse<Category> add(Category entity)
        {
            var response = new ServiceResponse<Category>();
            try
            {
                response.Entity = categoryRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Category> delete(Expression<Func<Category, bool>> expression)
        {
            var response = new ServiceResponse<Category>();
            try
            {
                response.IsSuccessful = categoryRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Category> get(Expression<Func<Category, bool>> expression)
        {
            var response = new ServiceResponse<Category>();
            try
            {
                response.Entity = categoryRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Category> getList()
        {
            var response = new ServiceResponse<Category>();
            try
            {
                response.List = categoryRepository.GetAll().ToList();
                response.Count = categoryRepository.Count();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Category> getList(Expression<Func<Category, bool>> expression)
        {
            var response = new ServiceResponse<Category>();
            try
            {
                var list = categoryRepository.Table.Where(expression).ToList();
                response.Count = list.Count;
                response.List = list;
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public PaginedResponse<Category> pagination(Expression<Category> expression, int pageNo, int showCount)
        {
            var response = new PaginedResponse<Category>();
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

        public ServiceResponse<Category> update(Category entity)
        {
            var response = new ServiceResponse<Category>();
            try
            {
                response.Entity = categoryRepository.Update(entity);
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

