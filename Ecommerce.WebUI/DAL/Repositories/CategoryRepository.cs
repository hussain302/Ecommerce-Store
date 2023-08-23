using Ecommerce.WebUI.DAL.IRepositories;
using ProductServices.Models.Entities;

namespace Ecommerce.WebUI.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string APIURL = "https://localhost:5000";
        public CategoryRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(APIURL); // Set the base address here

        }

        public async Task<bool> Add(Category category)
        {
            // Implement the logic to add a category via API
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"/categories", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            // Implement the logic to delete a category via API
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/categories/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Category> Get(int id)
        {
            // Implement the logic to get a category by id via API
            HttpResponseMessage response = await _httpClient.GetAsync($"/categories/{id}");
            if (response.IsSuccessStatusCode)
            {   
                var data = await response.Content.ReadFromJsonAsync<Category>(); // Use ReadFromJsonAsync
                return data;
            }
            return null;
        }

        public async Task<IAsyncEnumerable<Category>> GetAll()
        {
            // Implement the logic to get all categories via API
            HttpResponseMessage response = await _httpClient.GetAsync($"/categories");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<IAsyncEnumerable<Category>>(); // Use ReadFromJsonAsync
                return data;
            }
            return null;
        }

        public async Task<bool> Update(Category category)
        {
            // Implement the logic to update a category via API
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"/categories", category);
            return response.IsSuccessStatusCode;
        }
    }
}
