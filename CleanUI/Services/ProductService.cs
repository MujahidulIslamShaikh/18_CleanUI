using CleanUI.Models;
using Microsoft.VisualBasic.FileIO;
using System.Net.Http.Json;

namespace CleanUI.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public async Task CreateProduct(Product product)
        {
            await _http.PostAsJsonAsync("api/Products/CreateProduct", product);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _http.GetFromJsonAsync<List<Product>>("api/Products");
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _http.GetFromJsonAsync<Product>($"api/Products/{id}");
        }
        
        public async Task UpdateProduct(Product? product)
        {
            await _http.PutAsJsonAsync("api/Products/UpdateProduct", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _http.DeleteAsync($"api/Products/DeleteProduct/{id}");
        }


    }
}
