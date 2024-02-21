using DataAccess.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly KRSDbContext _context;

        public AccountController(KRSDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccountDTO>> GetAccounts()
        {
            var accounts = _context.Accounts
                .Select(a => new AccountDTO
                {
                    AccountId = a.AccountId,
                    UserName = a.UserName,
                    Email = a.Email,
                    IsVerify = a.IsVerify,
                    CreateDate = a.CreateDate,
                    ProgressId = a.ProgressId,
                    Status = a.Status,
                    ProfilePicture = a.ProfilePicture,
                    RoleId = a.RoleId
                })
                .ToList();

            return accounts;
        }

        [HttpGet("{id}")]
        public ActionResult<AccountDTO> GetAccount(int id)
        {
            var account = _context.Accounts
                .Where(a => a.AccountId == id)
                .Select(a => new AccountDTO
                {
                    AccountId = a.AccountId,
                    UserName = a.UserName,
                    Email = a.Email,
                    IsVerify = a.IsVerify,
                    CreateDate = a.CreateDate,
                    ProgressId = a.ProgressId,
                    Status = a.Status,
                    ProfilePicture = a.ProfilePicture,
                    RoleId = a.RoleId
                })
                .FirstOrDefault();

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

      
    }
}
