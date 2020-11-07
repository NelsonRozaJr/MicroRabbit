using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly ILogger<BankingController> _logger;

        private readonly IAccountService _accountService;

        public BankingController(ILogger<BankingController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            var accounts = _accountService.GetAccounts();
            return Ok(accounts);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AccountTransfer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountTransfer>> Post([FromBody] AccountTransfer accountTransfer)
        {
            var result = await _accountService.Transfer(accountTransfer);
            if (result)
            {
                return Ok(accountTransfer);
            }
            else
            {
                return BadRequest("Error while executing transfer.");
            }
        }
    }
}
