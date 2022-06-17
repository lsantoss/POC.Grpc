using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using POC.Grpc.Api.Domain.Customers.Mappers;
using POC.Grpc.Lib.Contract.Proto.Common.MessagesRequest;
using POC.Grpc.Lib.Contract.Proto.Customers.MessagesResponse;
using POC.Grpc.Lib.Contract.Proto.Customers.Services;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Application.Grpc
{
    public class CustomerGrpcService : CustomerService.CustomerServiceBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerGrpcService(ICustomerRepository repository) => _repository = repository;

        public override async Task<CustomerResponse> Get(GetByInt64IdRequest request, ServerCallContext context)
        {
            var customer = await _repository.GetAsync(request.Id);
            return customer.MapToCustomerResponse();
        }

        public override async Task<CustomerListResponse> List(Empty request, ServerCallContext context)
        {
            var customers = await _repository.ListAsync();
            return customers.MapToCustomerListResponse();
        }
    }
}