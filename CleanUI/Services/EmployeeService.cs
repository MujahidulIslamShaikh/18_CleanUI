using CleanUI.Models;
using System.Net.Http.Json;


namespace CleanUI.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _http;

        public EmployeeService(HttpClient httpClient)
        {
            _http = httpClient;
        }


        public async Task CreateEmpoloyee(EmployeeModel employee)
        {
            await _http.PostAsJsonAsync("api/Employee/CreateEmployee", employee);
        }


    }
}
