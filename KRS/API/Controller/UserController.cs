using DataAccess.DTO;
using BusinessObjects.Models;
using DataAccess.IRepository;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IAccountRepository _repository;

        public UserController(IAccountRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Authenticate(LoginRequestDTO userCredentials)
        {
            var account = _repository.Login(userCredentials);

            if (account == null)
            {
                return BadRequest("Tên người dùng hoặc mật khẩu không chính xác. Vui lòng thử lại.");
            }

          
            return Ok(new { Message = "Authentication successful" });
        }
    }
}
