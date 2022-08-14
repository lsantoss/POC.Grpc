using Google.Protobuf.WellKnownTypes;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Grpc;
using POC.Grpc.App.Domain.Customers.Mappers;
using POC.Grpc.App.Domain.Customers.Models;
using POC.Grpc.Lib.Contract.Proto.Common.MessagesRequest;
using System.Collections.Generic;
using System.Threading.Tasks;
using static POC.Grpc.Lib.Contract.Proto.Customers.Services.CustomerService;

namespace POC.Grpc.App.Infra.Service.Customers.Services.Grpc
{
    public class CustomerGrpcService : ICustomerGrpcService
    {
        private readonly CustomerServiceClient _customerServiceClient;

        public CustomerGrpcService(CustomerServiceClient customerServiceClient) => _customerServiceClient = customerServiceClient;

        public async Task<CustomerViewModel> GetAsync(long id)
        {
            var request = new GetByInt64IdRequest() { Id = id };
            var customerResponse = await _customerServiceClient.GetAsync(request);
            return customerResponse.MapToCustomerViewModel();
        }

        public async Task<List<CustomerViewModel>> ListAsync()
        {
            var customerListResponse = await _customerServiceClient.ListAsync(new Empty());
            return customerListResponse.MapToListOfCustomerViewModel();
        }
    }
}