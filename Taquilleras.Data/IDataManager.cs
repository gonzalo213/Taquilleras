using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Taquilleras.Data
{
    public interface IDataManager<T>
    {
        Task<T> CreateAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task UpdateAsync(T entity);

        Task<T> GetAsync(int? id);

    }
}
