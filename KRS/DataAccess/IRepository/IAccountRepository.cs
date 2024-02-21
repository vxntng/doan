
using BusinessObjects.Models;
using DataAccess.DTO;

namespace DataAccess.IRepository
{
    public interface IAccountRepository
    {
        Account GetAccByID(int accID);
        Account Login(LoginRequestDTO userCredentials);
		Task InsertAccount(Account acc);
		Task UpdateAccount(Account acc);
        Task DeleteAccount(int accID);
        Account GetAccByUsername(string username);
    }
}
