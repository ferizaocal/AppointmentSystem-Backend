using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeManager(IEmployeeRepository employee)
        {
            employeeRepository = employee;
        }

        public ServiceResponse<Employee> add(Employee entity)
        {
            var response = new ServiceResponse<Employee>();
            try
            {
                response.Entity = employeeRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Employee> delete(Expression<Func<Employee, bool>> expression)
        {
            var response = new ServiceResponse<Employee>();
            try
            {
                response.IsSuccessful = employeeRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Employee> get(Expression<Func<Employee, bool>> expression)
        {
            var response = new ServiceResponse<Employee>();
            try
            {
                response.Entity = employeeRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Employee> getList()
        {
            var response = new ServiceResponse<Employee>();
            try
            {
                response.List = employeeRepository.GetAll().ToList();
                response.Count = employeeRepository.Count();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Employee> getList(Expression<Func<Employee, bool>> expression)
        {
            var response = new ServiceResponse<Employee>();
            try
            {
                var list = employeeRepository.GetAll().ToList();
                response.Count = list.Count();
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

        public PaginedResponse<Employee> pagination(Expression<Employee> expression, int pageNo, int showCount)
        {
            var response = new PaginedResponse<Employee>();
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

        public ServiceResponse<Employee> update(Employee entity)
        {
            var response = new ServiceResponse<Employee>();
            try
            {
                response.Entity = employeeRepository.Update(entity);
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

