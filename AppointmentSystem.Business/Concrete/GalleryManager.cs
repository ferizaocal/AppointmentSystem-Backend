using System;
using System.Linq;
using System.Linq.Expressions;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Business.Concrete
{
    public class GalleryManager : IGalleryService
    {
        private readonly IGalleryRepository galleryRepository;
        public GalleryManager(IGalleryRepository gallery)
        {
            galleryRepository = gallery;
        }

        public ServiceResponse<Gallery> add(Gallery entity)
        {
            var response = new ServiceResponse<Gallery>();
            try
            {
                response.Entity = galleryRepository.Create(entity);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Gallery> delete(Expression<Func<Gallery, bool>> expression)
        {
            var response = new ServiceResponse<Gallery>();
            try
            {
                response.IsSuccessful = galleryRepository.Delete(expression);
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Gallery> get(Expression<Func<Gallery, bool>> expression)
        {
            var response = new ServiceResponse<Gallery>();
            try
            {
                response.Entity = galleryRepository.get(expression);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Gallery> getList()
        {
            var response = new ServiceResponse<Gallery>();
            try
            {
                response.List = galleryRepository.GetAll().ToList();
                response.Count = galleryRepository.Count();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public ServiceResponse<Gallery> getList(Expression<Func<Gallery, bool>> expression)
        {
            var response = new ServiceResponse<Gallery>();
            try
            {
                var list = galleryRepository.GetAll().ToList();
                response.List = list;
                response.Count = list.Count();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.HasExceptionError = true;
                response.ExceptionMessage = ex.ToString();
            }
            return response;
        }

        public PaginedResponse<Gallery> pagination(Expression<Gallery> expression, int pageNo, int showCount)
        {
            var response = new PaginedResponse<Gallery>();
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

        public ServiceResponse<Gallery> update(Gallery entity)
        {
            var response = new ServiceResponse<Gallery>();
            try
            {
                response.Entity = galleryRepository.Update(entity);
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

