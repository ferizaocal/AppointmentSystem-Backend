using System;
using System.Linq.Expressions;

namespace AppointmentSystem.Business
{
    public interface IService<T>
    {
        ServiceResponse<T> add(T entity);
        ServiceResponse<T> update(T entity);
        ServiceResponse<T> get(Expression<Func<T, bool>> expression);
        ServiceResponse<T> getList();
        ServiceResponse<T> getList(Expression<Func<T, bool>> expression);
        ServiceResponse<T> delete(Expression<Func<T, bool>> expression);
    }
    public interface IPagination<T>
    {
        PaginedResponse<T> pagination(Expression<T> expression, int pageNo, int showCount);
    }
}

