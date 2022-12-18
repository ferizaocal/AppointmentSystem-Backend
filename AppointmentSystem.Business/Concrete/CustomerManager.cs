using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerManager(ICustomerRepository customer)
        {
            customerRepository = customer;
        }

        public ServiceResponse<Customer> add(Customer entity)
        {
            var response = new ServiceResponse<Customer>();
            try
            {
                response.Entity = customerRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Customer> delete(Expression<Func<Customer, bool>> expression)
        {
            var response = new ServiceResponse<Customer>();
            try
            {
                response.IsSuccessful = customerRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Customer> get(Expression<Func<Customer, bool>> expression)
        {
            var response = new ServiceResponse<Customer>();
            try
            {
                response.Entity = customerRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Customer> getList()
        {
            var response = new ServiceResponse<Customer>();
            try
            {
                response.Count = customerRepository.Count();
                response.List = customerRepository.GetAll().ToList();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Customer> getList(Expression<Func<Customer, bool>> expression)
        {
            var response = new ServiceResponse<Customer>();
            try
            {
                var list = customerRepository.Table.Where(expression).ToList();
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

        public PaginedResponse<Customer> pagination(Expression<Customer> expression, int pageNo, int showCount)
        {
            var response = new PaginedResponse<Customer>();
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

        public ServiceResponse<Customer> update(Customer entity)
        {
            var response = new ServiceResponse<Customer>();
            try
            {
                response.Entity = customerRepository.Update(entity);
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

