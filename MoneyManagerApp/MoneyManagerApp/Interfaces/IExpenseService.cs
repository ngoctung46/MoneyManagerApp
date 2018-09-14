using MoneyManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetByCaseId(string caseId);
    }
}