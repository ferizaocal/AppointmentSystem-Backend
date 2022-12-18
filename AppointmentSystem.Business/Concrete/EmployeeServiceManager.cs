using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
    public class EmployeeServiceManager : IEmployeeServiceService
    {
        private readonly IEmployeeServiceRepository employeeServiceRepository;
        public EmployeeServiceManager(IEmployeeServiceRepository serviceRepository)
        {
            employeeServiceRepository = serviceRepository;
        }

        public ServiceResponse<EmployeeService> add(EmployeeService entity)
        {
            var response = new ServiceResponse<EmployeeService>();
            try
            {
                response.Entity = employeeServiceRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<EmployeeService> delete(Expression<Func<EmployeeService, bool>> expression)
        {
            var response = new ServiceResponse<EmployeeService>();
            try
            {
                response.IsSuccessful = employeeServiceRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<EmployeeService> get(Expression<Func<EmployeeService, bool>> expression)
        {
            var response = new ServiceResponse<EmployeeService>();
            try
            {
                response.Entity = employeeServiceRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<EmployeeService> getList()
        {
            var response = new ServiceResponse<EmployeeService>();
            try
            {
                response.Count = employeeServiceRepository.Count();
                response.List = employeeServiceRepository.GetAll().ToList();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<EmployeeService> getList(Expression<Func<EmployeeService, bool>> expression)
        {
            var response = new ServiceResponse<EmployeeService>();
            try
            {
                var list = employeeServiceRepository.GetAll().ToList();
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

        public PaginedResponse<EmployeeService> pagination(Expression<EmployeeService> expression, int pageNo, int showCount)
        {
            var response = new PaginedResponse<EmployeeService>();
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

        public ServiceResponse<EmployeeService> update(EmployeeService entity)
        {
            var response = new ServiceResponse<EmployeeService>();
            try
            {
                response.Entity = employeeServiceRepository.Update(entity);
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

