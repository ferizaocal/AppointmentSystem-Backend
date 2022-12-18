using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AppointmentSystem.Business.Concrete
{
    public class CoiffeurManager : ICoiffeurService
    {
        private readonly ICoiffeurRepository coiffeurRepository;
        public CoiffeurManager(ICoiffeurRepository coiffeur)
        {
            coiffeurRepository = coiffeur;
        }

        public ServiceResponse<Coiffeur> add(Coiffeur entity)
        {
            var response = new ServiceResponse<Coiffeur>();
            try
            {
                response.Entity = coiffeurRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Coiffeur> Authentication(string email, string password)
        {
            var response = new ServiceResponse<Coiffeur>();
            try
            {
                var loginCheck = coiffeurRepository.get(x => x.Email == email && x.Password == password);
                if (loginCheck == null)
                {
                    throw new Exception("Email or password is incorrect");
                }
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Coiffeur> delete(Expression<Func<Coiffeur, bool>> expression)
        {
            var response = new ServiceResponse<Coiffeur>();
            try
            {
                response.IsSuccessful = coiffeurRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Coiffeur> get(Expression<Func<Coiffeur, bool>> expression)
        {
            var response = new ServiceResponse<Coiffeur>();
            try
            {
                response.Entity = coiffeurRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Coiffeur> getList()
        {
            var response = new ServiceResponse<Coiffeur>();
            try
            {
                response.List = coiffeurRepository.GetAll().ToList();
                response.Count = coiffeurRepository.Count();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Coiffeur> getList(Expression<Func<Coiffeur, bool>> expression)
        {
            var response = new ServiceResponse<Coiffeur>();
            try
            {
                var list = coiffeurRepository.Table.Where(expression).ToList();
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

        public ServiceResponse<Coiffeur> update(Coiffeur entity)
        {
            var response = new ServiceResponse<Coiffeur>();
            try
            {
                response.Entity = coiffeurRepository.Update(entity);
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

