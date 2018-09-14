using MoneyManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.Interfaces
{
    public interface IExpenseRepo : IRepo<Expense>
    {
        Task<IEnumerable<Expense>> GetAll();

        Task<Expense> GetOne(string id);

        Task<Expense> UpdateOne(Expense item);

        Task<Expense> AddOne(Expense item);

        Task<Expense> DeleteOne(string id);

        Task<bool> AddRange(IEnumerable<Expense> items);

        Task<bool> UpdateRange(IEnumerable<Expense> items);

        Task<bool> DeleteRange(IEnumerable<Expense> items);

        Task<IEnumerable<Expense>> GetRange(int skip, int take);

        Task<IEnumerable<Expense>> GetByCaseId(string caseId);
    }
}