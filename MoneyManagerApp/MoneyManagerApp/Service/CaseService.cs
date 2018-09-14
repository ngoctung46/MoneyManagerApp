using MoneyManagerApp.Interfaces;
using MoneyManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.Service
{
    public class CaseService : ICaseService
    {
        private ICaseRepo caseRepo;
        private IExpenseRepo expenseRepo;

        public CaseService(ICaseRepo caseRepo, IExpenseRepo expenseRepo)
        {
            this.caseRepo = caseRepo;
            this.expenseRepo = expenseRepo;
        }

        public async Task<Expense> AddExpense(string caseId, Expense expense)
        {
            expense.CaseId = caseId;
            return await expenseRepo.AddOne(expense);
        }

        public async Task<Case> AddOne(Case _case)
        {
            return await caseRepo.AddOne(_case);
        }

        public Task<bool> AddRange(IEnumerable<Case> cases)
        {
            return caseRepo.AddRange(cases);
        }

        public async Task<Case> DeleteOne(Case _case)
        {
            return await caseRepo.DeleteOne(_case.Id);
        }

        public async Task<bool> DeleteRange(IEnumerable<Case> cases)
        {
            return await caseRepo.DeleteRange(cases);
        }

        public async Task<IEnumerable<Case>> GetAll()
            => await caseRepo.GetAll();

        public Task<IEnumerable<Expense>> GetExpenses(string caseId)
        {
            return expenseRepo.GetByCaseId(caseId);
        }

        public async Task<Case> GetOne(string id)
        {
            return await caseRepo.GetOne(id);
        }

        public async Task<Expense> RemoveExpense(string id)
        {
            return await expenseRepo.DeleteOne(id);
        }

        public async Task<Expense> UpdateExpense(Expense expense)
        {
            return await expenseRepo.UpdateOne(expense);
        }

        public async Task<Case> UpdateOne(Case _case)
        {
            return await caseRepo.UpdateOne(_case);
        }

        public Task<bool> UpdateRange(IEnumerable<Case> cases)
        {
            return caseRepo.UpdateRange(cases);
        }
    }
}