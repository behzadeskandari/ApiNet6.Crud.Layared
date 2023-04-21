using ApiNet6.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Common.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetFilteredAysnc(Expression<Func<T, bool>>[] fillters, int? skip, int? take,params Expression<Func<T, object>>[] includes);

        Task<List<T>> GetAysnc(int? skip, int? take, params Expression<Func<T, object>>[] includes);


        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);

        Task<int> InsertAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChangesAsync();
    
    }
}
