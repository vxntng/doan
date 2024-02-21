
using BusinessObjects.Models;
using DataAccess.DAO;
using DataAccess.DTO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Task DeleteAccount(int accID) => AccountManagement.Instance.Delete(accID);

        public Account GetAccByID(int accID) => AccountManagement.Instance.GetAccountByID(accID);


        public Account GetAccByUsername(string username) => AccountManagement.Instance.GetAccountByUsername(username);

        public Task InsertAccount(Account acc) => AccountManagement.Instance.AddNew(acc);
        public Account Login(LoginRequestDTO userCredentials) => AccountManagement.Instance.Login(userCredentials);

        public Task UpdateAccount(Account acc) => AccountManagement.Instance.Update(acc);



    }
}
