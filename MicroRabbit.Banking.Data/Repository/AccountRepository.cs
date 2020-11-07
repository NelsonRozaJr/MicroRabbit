using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;

        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts.ToArray();
        }

        public Account GetAccount(int id)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == id);
        }

        public async Task Update(Account account)
        {
            account.UpdateDate = DateTime.Now;

            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ProcessTransferAsync(int from, int to, decimal amount)
        {
            bool result = false;

            var fromAccount = GetAccount(from);
            if (fromAccount != null)
            {
                var toAccount = GetAccount(to);
                if (toAccount != null)
                {
                    var balanceFrom = fromAccount.AccountBalance;
                    if (balanceFrom >= amount)
                    {
                        using var transaction = _context.Database.BeginTransaction();

                        fromAccount.AccountBalance = balanceFrom - amount;
                        await Update(fromAccount);

                        toAccount.AccountBalance += amount;
                        await Update(toAccount);

                        await transaction.CommitAsync();

                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
