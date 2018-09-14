using MoneyManagerApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.Interfaces
{
    public interface IRepo<T> where T : ModelBase
    {
        Task<T> PostAsync(T entity);

        Task<T> PutAsync(T entity);

        Task<T> DeleteAsync(string id);

        Task<IEnumerable<T>> GetAsync();

        Task<T> GetByIdAsync(string id);
    }
}