
using BusinessObjects.Models;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class LoginResponseDTO
    {
        public int AccId { get; set; }
        public string Username { get; set; }

        public int Role { get; set; }
        public string Token { get; set; }

        public LoginResponseDTO() {
        
        }

        public LoginResponseDTO(Account acc, string token)
        {
            AccId = acc.AccountId;
            Username = acc.UserName;
            Token = token;
            
        }
    }
}
