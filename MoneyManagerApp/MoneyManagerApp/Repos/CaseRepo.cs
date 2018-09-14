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
    public class CaseRepo : RepoBase<Case>, ICaseRepo
    {
        private readonly IExpenseRepo expenseRepo;

        public CaseRepo(IExpenseRepo expenseRepo)
        {
            this.expenseRepo = expenseRepo;
        }

        public async Task<IEnumerable<Case>> GetAll()
            => await GetAsync();

        public async Task<Case> GetOne(string id)
            => await GetByIdAsync(id);

        public async Task<Case> UpdateOne(Case item)
            => await PutAsync(item);

        public async Task<Case> AddOne(Case item)
            => await PostAsync(item);

        public async Task<Case> DeleteOne(string id)
        {
            var expenses = await expenseRepo.GetByCaseId(id);
            var success = await expenseRepo.DeleteRange(expenses);
            if (success) return await DeleteAsync(id);
            return null;
        }

        public async Task<bool> AddRange(IEnumerable<Case> items)
        {
            try
            {
                foreach (var item in items)
                {
                    await AddOne(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteRange(IEnumerable<Case> items)
        {
            try
            {
                foreach (var item in items)
                {
                    await DeleteOne(item.Id);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateRange(IEnumerable<Case> items)
        {
            try
            {
                foreach (var item in items)
                {
                    await UpdateOne(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Case>> GetRange(int skip, int take)
        {
            var list = await GetAll();
            return list.OrderByDescending(x => x.CreatedAt).Skip(skip).Take(take);
        }
    }
}