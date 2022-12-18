using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceRepository serviceRepository;
        public ServiceManager(IServiceRepository service)
        {
            serviceRepository = service;
        }

        public ServiceResponse<Service> add(Service entity)
        {
            var response = new ServiceResponse<Service>();
            try
            {
                response.Entity = serviceRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Service> delete(Expression<Func<Service, bool>> expression)
        {
            var response = new ServiceResponse<Service>();
            try
            {
                response.IsSuccessful = serviceRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Service> get(Expression<Func<Service, bool>> expression)
        {
            var response = new ServiceResponse<Service>();
            try
            {
                response.Entity = serviceRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Service> getList()
        {
            var response = new ServiceResponse<Service>();
            try
            {
                response.List = serviceRepository.GetAll().ToList();
                response.Count = serviceRepository.Count();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Service> getList(Expression<Func<Service, bool>> expression)
        {
            var response = new ServiceResponse<Service>();
            try
            {
                var list = serviceRepository.GetAll().ToList();
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

        public PaginedResponse<Service> pagination(Expression<Service> expression, int pageNo, int showCount)
        {
            var response = new PaginedResponse<Service>();
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

        public ServiceResponse<Service> update(Service entity)
        {
            var response = new ServiceResponse<Service>();
            try
            {
                response.Entity = serviceRepository.Update(entity);
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

