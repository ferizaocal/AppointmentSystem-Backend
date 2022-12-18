using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
    public class WorkingHoursManager : IWorkingHoursService
    {
        private readonly IWorkingHoursRepository workingHoursRepository;
        public WorkingHoursManager(IWorkingHoursRepository workingHours)
        {
            workingHoursRepository = workingHours;
        }

        public ServiceResponse<WorkingHours> add(WorkingHours entity)
        {
            var response = new ServiceResponse<WorkingHours>();
            try
            {
                response.Entity = workingHoursRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<WorkingHours> delete(Expression<Func<WorkingHours, bool>> expression)
        {
            var response = new ServiceResponse<WorkingHours>();
            try
            {
                response.IsSuccessful = workingHoursRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<WorkingHours> get(Expression<Func<WorkingHours, bool>> expression)
        {
            var response = new ServiceResponse<WorkingHours>();
            try
            {
                response.Entity = workingHoursRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<WorkingHours> getList()
        {
            var response = new ServiceResponse<WorkingHours>();
            try
            {
                response.List = workingHoursRepository.GetAll().ToList();
                response.Count = workingHoursRepository.Count();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<WorkingHours> getList(Expression<Func<WorkingHours, bool>> expression)
        {
            var response = new ServiceResponse<WorkingHours>();
            try
            {
                var list = workingHoursRepository.GetAll().ToList();
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

        public ServiceResponse<WorkingHours> update(WorkingHours entity)
        {
            var response = new ServiceResponse<WorkingHours>();
            try
            {
                response.Entity = workingHoursRepository.Update(entity);
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

