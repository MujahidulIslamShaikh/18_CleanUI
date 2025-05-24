using System.Net.Http.Json;
using Blazored.LocalStorage;
using CleanUI.Models;

namespace CleanUI.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        public async Task<string> Register(RegisterModel model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", model);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Login(LoginModel model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", model);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                await _localStorage.SetItemAsync("authToken", result.Token); // save token
                _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.Token); // attach token
                return "Login successful";
            }

            return await response.Content.ReadAsStringAsync();

        }
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _http.DefaultRequestHeaders.Authorization = null;

 
        }
    }
}

