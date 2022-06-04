using Google.Protobuf.WellKnownTypes;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Grpc;
using POC.Grpc.App.Domain.Customers.Mappers;
using POC.Grpc.App.Domain.Customers.Models;
using POC.Grpc.Lib.Proto.Common.MessagesRequest;
using System.Collections.Generic;
using System.Threading.Tasks;
using static POC.Grpc.Lib.Proto.Customers.Services.CustomerService;

namespace POC.Grpc.App.Infra.Service.Services.Grpc
{
    public class CustomerGrpcService : ICustomerGrpcService
    {
        private readonly CustomerServiceClient _customerServiceClient;

        public CustomerGrpcService(CustomerServiceClient customerServiceClient) => _customerServiceClient = customerServiceClient;

        public async Task<CustomerViewModel> Get(long id)
        {
            var request = new GetByInt64IdRequest() { Id = id };
            var customerResponse = await _customerServiceClient.GetAsync(request);
            var customer = customerResponse.MapToCustomerViewModel();
            return customer;
        }

        public async Task<List<CustomerViewModel>> List()
        {
            var customerListResponse = await _customerServiceClient.ListAsync(new Empty());
            var customers = customerListResponse.MapToListOfCustomerViewModel();
            return customers;
        }
    }
}