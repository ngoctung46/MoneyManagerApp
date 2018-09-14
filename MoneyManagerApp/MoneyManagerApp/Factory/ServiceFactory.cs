using MoneyManagerApp.Repos;
using MoneyManagerApp.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagerApp.Factory
{
    public static class ServiceFactory
    {
        public static CaseService CreateCaseService()
        {
            var expenseRepo = new ExpenseRepo();
            var repo = new CaseRepo(expenseRepo);
            return new CaseService(repo, expenseRepo);
        }

        public static ExpenseService CreateExpenseService()
        {
            var repo = new ExpenseRepo();
            return new ExpenseService(repo);
        }
    }
}