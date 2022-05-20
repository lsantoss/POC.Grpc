using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using POC.Grpc.Api.Domain.Customers.Mappers;
using POC.Grpc.Lib.Proto.Messages.Request;
using POC.Grpc.Lib.Proto.Messages.Response;
using POC.Grpc.Lib.Proto.Services;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Application.Grpc
{
    public class CustomerGrpcService : CustomerService.CustomerServiceBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerGrpcService(ICustomerRepository repository) => _repository = repository;

        public override Task<CustomerResponse> Get(GetByInt64IdRequest request, ServerCallContext context)
        {
            var customer = _repository.Get(request.Id);
            var response = customer.MapToCustomerResponse();
            return Task.FromResult(response);
        }

        public override Task<CustomerListResponse> List(Empty request, ServerCallContext context)
        {
            var customers = _repository.List();
            var response = customers.MapToCustomerListResponse();
            return Task.FromResult(response);
        }
    }
}