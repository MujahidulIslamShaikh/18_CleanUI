using System.Net.Http.Json;
using CleanUI.Models;

namespace CleanUI.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> Register(RegisterModel model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", model);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Login(LoginModel model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", model);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
