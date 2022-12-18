using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
    public class AppointmentServiceManager : IAppointmentServiceService
    {
        private readonly IAppointmentServiceRepository appointmentServiceRepository;
        public AppointmentServiceManager(IAppointmentServiceRepository  appointmentService)
        {
            appointmentServiceRepository = appointmentService;
        }
        public ServiceResponse<AppointmentService> add(AppointmentService entity)
        {
            var response = new ServiceResponse<AppointmentService>();
            try
            {
                response.Entity = appointmentServiceRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<AppointmentService> delete(Expression<Func<AppointmentService, bool>> expression)
        {
            var response = new ServiceResponse<AppointmentService>();
            try
            {
                response.IsSuccessful = appointmentServiceRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<AppointmentService> get(Expression<Func<AppointmentService, bool>> expression)
        {
            var response = new ServiceResponse<AppointmentService>();
            try
            {
                response.Entity = appointmentServiceRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<AppointmentService> getList()
        {
            var response = new ServiceResponse<AppointmentService>();
            try
            {
                response.List = appointmentServiceRepository.GetAll().ToList();
                response.Count = appointmentServiceRepository.Count();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<AppointmentService> getList(Expression<Func<AppointmentService, bool>> expression)
        {
            var response = new ServiceResponse<AppointmentService>();
            try
            {
                var list = appointmentServiceRepository.Table.Where(expression).ToList();
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

        public PaginedResponse<AppointmentService> pagination(Expression<AppointmentService> expression, int pageNo, int showCount)
        {
            var response = new PaginedResponse<AppointmentService>();
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

        public ServiceResponse<AppointmentService> update(AppointmentService entity)
        {
            var response = new ServiceResponse<AppointmentService>();
            try
            {
                response.Entity = appointmentServiceRepository.Update(entity);
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

