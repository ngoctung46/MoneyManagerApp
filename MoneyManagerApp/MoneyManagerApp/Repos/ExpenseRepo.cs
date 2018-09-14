using MoneyManagerApp.Interfaces;
using MoneyManagerApp.Models;
using MoneyManagerApp.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.Repos
{
    public class ExpenseRepo : RepoBase<Expense>, IExpenseRepo
    {
        public async Task<IEnumerable<Expense>> GetAll()
            => await GetAsync();

        public async Task<Expense> GetOne(string id)
            => await GetByIdAsync(id);

        public async Task<Expense> UpdateOne(Expense item)
            => await PutAsync(item);

        public async Task<Expense> AddOne(Expense item)
            => await PostAsync(item);

        public async Task<Expense> DeleteOne(string id)
            => await DeleteAsync(id);

        public async Task<bool> AddRange(IEnumerable<Expense> items)
        {
            try
            {
                foreach (var item in items)
                {
                    await AddOne(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRange(IEnumerable<Expense> items)
        {
            try
            {
                foreach (var item in items)
                {
                    await DeleteOne(item.Id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateRange(IEnumerable<Expense> items)
        {
            try
            {
                foreach (var item in items)
                {
                    await UpdateOne(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Expense>> GetRange(int skip, int take)
        {
            var list = await GetAll();
            return list.OrderByDescending(x => x.CreatedAt).Skip(skip).Take(take);
        }

        public async Task<IEnumerable<Expense>> GetByCaseId(string caseId)
        {
            var list = await GetAll();
            return list.Where(x => x.CaseId.Equals(caseId));
        }
    }
}