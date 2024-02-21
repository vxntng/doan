using DataAccess.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

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
                    Password = a.Password,
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
                    Password = a.Password,
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
        [HttpPost]
        public async Task<IActionResult> InsertAccount([FromBody] AccountDTO newAccount)
        {
            try
            {
                // Create a new Account entity based on the DTO
                var account = new Account
                {
                    UserName = newAccount.UserName,
                    Email = newAccount.Email,
                    Password = newAccount.Password, // Include the password
                    IsVerify = newAccount.IsVerify,
                    CreateDate = newAccount.CreateDate,
                    ProgressId = newAccount.ProgressId,
                    Status = newAccount.Status,
                    ProfilePicture = newAccount.ProfilePicture,
                    RoleId = newAccount.RoleId
                };

                // Add the new account to the context
                _context.Accounts.Add(account);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Return the created account with its new ID
                return CreatedAtAction(nameof(GetAccount), new { id = account.AccountId }, account);
            }
            catch (Exception ex)
            {
                // Log or inspect the exception details
                Console.WriteLine($"Error inserting account: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] AccountDTO updatedAccount)
        {
            try
            {
                // Check if the account with the given id exists
                var existingAccount = await _context.Accounts.FindAsync(id);

                if (existingAccount == null)
                {
                    return NotFound($"Account with ID {id} not found.");
                }

                // Update properties based on the DTO
                existingAccount.UserName = updatedAccount.UserName;
                existingAccount.Email = updatedAccount.Email;
                existingAccount.IsVerify = updatedAccount.IsVerify;
                existingAccount.ProgressId = updatedAccount.ProgressId;
                existingAccount.Status = updatedAccount.Status;
                existingAccount.ProfilePicture = updatedAccount.ProfilePicture;
                existingAccount.RoleId = updatedAccount.RoleId;

                // Save changes to the database
                await _context.SaveChangesAsync();

                return Ok($"Account with ID {id} updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                // Check if the account with the given id exists
                var existingAccount = await _context.Accounts.FindAsync(id);

                if (existingAccount == null)
                {
                    return NotFound($"Account with ID {id} not found.");
                }

                // Remove the account from the context
                _context.Accounts.Remove(existingAccount);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return Ok($"Account with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
