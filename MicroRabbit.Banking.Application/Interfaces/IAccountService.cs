using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();

        Task<bool> Transfer(AccountTransfer accountTransfer);
    }
}
