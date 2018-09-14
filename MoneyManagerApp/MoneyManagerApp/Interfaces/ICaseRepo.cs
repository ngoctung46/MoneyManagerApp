using MoneyManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.Interfaces
{
    public interface ICaseRepo
    {
        Task<IEnumerable<Case>> GetAll();

        Task<Case> GetOne(string id);

        Task<Case> UpdateOne(Case item);

        Task<Case> AddOne(Case item);

        Task<Case> DeleteOne(string id);

        Task<bool> AddRange(IEnumerable<Case> items);

        Task<bool> UpdateRange(IEnumerable<Case> items);

        Task<bool> DeleteRange(IEnumerable<Case> items);

        Task<IEnumerable<Case>> GetRange(int skip, int take);
    }
}