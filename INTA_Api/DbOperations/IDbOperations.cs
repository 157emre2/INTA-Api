using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INTA_Api.DbOperations;

public interface IDbOperations<T> where T : class
{
    Task<List<T>> GetAll();
    Task<List<T>> GetAllWithLanguage(string lang);
    Task<T> GetById(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<bool> Delete(T entity);
    Task<T> GetByFilterSingle(Expression<Func<T, bool>> filter);
    Task<bool> IsRecorded(Expression<Func<T, bool>> filter);
}
