using MoneyManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.Interfaces
{
    public interface ICaseService
    {
        Task<IEnumerable<Case>> GetAll();

        Task<Case> UpdateOne(Case _case);

        Task<Case> AddOne(Case _case);

        Task<Case> GetOne(string id);

        Task<Case> DeleteOne(Case _case);

        Task<bool> DeleteRange(IEnumerable<Case> cases);

        Task<bool> UpdateRange(IEnumerable<Case> cases);

        Task<bool> AddRange(IEnumerable<Case> cases);

        Task<IEnumerable<Expense>> GetExpenses(string id);

        Task<Expense> AddExpense(string caseId, Expense expense);

        Task<Expense> RemoveExpense(string id);

        Task<Expense> UpdateExpense(Expense expense);
    }
}