using MoneyManagerApp.Interfaces;
using MoneyManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.Service
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepo repo;

        public ExpenseService(IExpenseRepo repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Expense>> GetByCaseId(string caseId)
        {
            var list = await repo.GetByCaseId(caseId);
            return list.OrderByDescending(x => x.CreatedAt);
        }
    }
}