using Newtonsoft.Json;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Rest;
using POC.Grpc.App.Domain.Customers.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace POC.Grpc.App.Infra.Service.Services.Rest
{
    public class CustomerRestService : ICustomerRestService
    {
        private readonly HttpClient _httpClient;

        public CustomerRestService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<CustomerViewModel> Get(long id)
        {
            var responseString = await _httpClient.GetStringAsync($"v1/customers/{id}");
            var customer = JsonConvert.DeserializeObject<CustomerViewModel>(responseString);
            return customer;
        }

        public async Task<List<CustomerViewModel>> List()
        {
            var responseString = await _httpClient.GetStringAsync($"v1/customers");
            var customers = JsonConvert.DeserializeObject<List<CustomerViewModel>>(responseString);
            return customers;
        }
    }
}