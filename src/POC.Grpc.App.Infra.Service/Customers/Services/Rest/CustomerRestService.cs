using Newtonsoft.Json;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Rest;
using POC.Grpc.App.Domain.Customers.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace POC.Grpc.App.Infra.Service.Customers.Services.Rest
{
    public class CustomerRestService : ICustomerRestService
    {
        private readonly HttpClient _httpClient;

        public CustomerRestService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<CustomerViewModel> GetAsync(long id)
        {
            var responseString = await _httpClient.GetStringAsync($"v1/customers/{id}");
            return JsonConvert.DeserializeObject<CustomerViewModel>(responseString);
        }

        public async Task<List<CustomerViewModel>> ListAsync()
        {
            var responseString = await _httpClient.GetStringAsync($"v1/customers");
            return JsonConvert.DeserializeObject<List<CustomerViewModel>>(responseString);
        }
    }
}