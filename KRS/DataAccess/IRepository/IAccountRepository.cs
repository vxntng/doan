
using BusinessObjects.Models;
using DataAccess.DTO;

namespace DataAccess.IRepository
{
    public interface IAccountRepository
    {
        Account GetAccByID(int accID);
        Account Login(LoginRequestDTO userCredentials);
		Task InsertAccount(Account car);
		Task UpdateAccount(Account car);
        
        Account GetAccByUsername(string username);
    }
}
