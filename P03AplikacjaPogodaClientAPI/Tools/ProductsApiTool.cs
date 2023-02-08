using Microsoft.Extensions.Configuration;
using P05Sklep.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaPogodaClientAPI.Tools
{
    public class ProductsApiTool
    {
        private string _baseURL;
        public ProductsApiTool()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>();
            //.SetBasePath(Directory.GetCurrentDirectory()) //odwołanie do pliku config
            //.AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            _baseURL = configuration["products_base_url"];
        }

        public async Task<Product[]> GetProducts()
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);
                var result = await client.GetFromJsonAsync<ServiceResponse<Product[]>>("/api/product");

                return result.Data;
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);
                var result = await client.PutAsJsonAsync("/api/product", product);
                var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Product>>();

                return content.Data;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);
                var result = await client.DeleteAsync($"/api/product/{id}");
                return true;
            }
        }

        internal async Task<Product> CreateProduct(Product productToCreate)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);
                var result = await client.PostAsJsonAsync("/api/product", productToCreate);
                var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Product>>();

                return content.Data;
            }
        }
    }
}
