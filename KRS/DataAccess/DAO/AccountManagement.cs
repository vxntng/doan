
using BusinessObjects.Models;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class AccountManagement
    {
        private static AccountManagement instance = null;
        private static readonly object instanceLock = new object();
        private AccountManagement() { }
        public static AccountManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountManagement();
                    }
                    return instance;
                }
            }
        }


        public Account GetAccountByID(int accID)
        {
            Account car = null;
            try
            {
                var KRSDB = new KRSDbContext();
                car = KRSDB.Accounts.SingleOrDefault(acc => acc.AccountId == accID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        public Account GetAccountByUsername(string username)
        {
            Account car = null;
            try
            {
                var KRSDB = new KRSDbContext();
                car = KRSDB.Accounts.SingleOrDefault(acc => acc.UserName == username);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        public Account GetAccountByUserPass(string username, string password)
        {
            Account car = null;
            try
            {
                var KRSDB = new KRSDbContext();
                car = KRSDB.Accounts.FirstOrDefault(u => u.UserName == username && u.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        public async Task AddNew(Account acc)
        {
            try
            {
                Account _acc = GetAccountByID(acc.AccountId);
                if (_acc == null)
                {
                    var KRSDB = new KRSDbContext();
					await KRSDB.Accounts.AddAsync(acc);
					await KRSDB.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("The account is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Account Login(LoginRequestDTO userCredentials)
        {
            using (var _context = new KRSDbContext())
            {
                var account = _context.Accounts.FirstOrDefault(a => a.UserName == userCredentials.UserName && a.Password == userCredentials.Password);
                if (account != null)
                {
                    return account;
                }
            }
            return null;
        }
        

        public async Task Update(Account acc)
        {
            try
            {
                Account c = GetAccountByID(acc.AccountId);
                if (c != null)
                {
                    var KRSDB = new KRSDbContext();
					KRSDB.Entry<Account>(acc).State = EntityState.Modified;
					await KRSDB.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("The account does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int accID)
        {
            try
            {
                Account accToDelete = GetAccountByID(accID);
                if (accToDelete != null)
                {
                    var KRSDB = new KRSDbContext();
                    KRSDB.Accounts.Remove(accToDelete);
                    await KRSDB.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("The account does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

