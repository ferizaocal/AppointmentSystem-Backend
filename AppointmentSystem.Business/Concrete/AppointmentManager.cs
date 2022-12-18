using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IAppointmentServiceRepository appointmentServiceRepository;

        public AppointmentManager(IAppointmentRepository appointment,IAppointmentServiceRepository appointmentService)
        {
            appointmentRepository = appointment;
            appointmentServiceRepository = appointmentService;
        }

        public ServiceResponse<Appointment> add(Appointment entity)
        {
            var response = new ServiceResponse<Appointment>();
            try
            {
                response.Entity = appointmentRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Appointment> add(Appointment appointment, List<AppointmentService> appointmentService)
        {
            var response = new ServiceResponse<Appointment>();
            try
            {
                response.Entity = appointmentRepository.Create(appointment);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Appointment> delete(Expression<Func<Appointment, bool>> expression)
        {
            var response = new ServiceResponse<Appointment>();
            try
            {
                response.IsSuccessful = appointmentRepository.Delete(expression) ;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Appointment> get(Expression<Func<Appointment, bool>> expression)
        {
            var response = new ServiceResponse<Appointment>();
            try
            {
                response.Entity = appointmentRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Appointment> getList()
        {
            var response = new ServiceResponse<Appointment>();
            try
            {
                response.List = appointmentRepository.GetAll().ToList();
                response.Count = appointmentRepository.Count();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Appointment> getList(Expression<Func<Appointment, bool>> expression)
        {
            var response = new ServiceResponse<Appointment>();
            try
            {
                var list = appointmentRepository.Table.Where(expression).ToList();
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

        public PaginedResponse<Appointment> pagination(Expression<Appointment> expression, int pageNo, int showCount)
        {
            var response = new PaginedResponse<Appointment>();
            try
            {

            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Appointment> update(Appointment entity)
        {
            var response = new ServiceResponse<Appointment>();
            try
            {
                response.Entity = appointmentRepository.Update(entity);
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

