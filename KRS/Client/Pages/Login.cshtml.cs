using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using DataAccess.DTO;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Client.Pages
{
    public class LoginModel : PageModel
    {

        private readonly HttpClient client;
        private string userUrl;
      
        [BindProperty]
        public LoginRequestDTO Input { get; set; }

        public LoginModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            userUrl = "http://localhost:5046/api/User";
        }



        public async Task<IActionResult> OnPostAsync(string userName, string passWord)
        {
            var response = await client.PostAsJsonAsync(userUrl + "/Authenticate", new { userName = userName, passWord = passWord });
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                LoginRequestDTO userRequest = System.Text.Json.JsonSerializer.Deserialize<LoginRequestDTO>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return RedirectToAction("Index","Account");
            } else
            {
                ModelState.AddModelError(string.Empty, "Wrong username or password");
                return Page();

            }
        }
    }
}
