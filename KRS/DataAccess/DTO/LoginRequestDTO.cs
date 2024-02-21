using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
