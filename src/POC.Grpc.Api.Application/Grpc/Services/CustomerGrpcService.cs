using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using POC.Grpc.Client.Lib.Protos.Customers.Services;
using static POC.Grpc.Client.Lib.Protos.Customers.Services.CustomerService;

namespace POC.Grpc.Api.Application.Grpc.Services;

public class CustomerGrpcService : CustomerServiceBase
{
    private static readonly RepeatedField<Customer> _customers = [];

    public override Task<GetResponse> Get(GetRequest request, ServerCallContext context)
    {
        var customer = _customers.Where(x => x.Id == request.Id).FirstOrDefault();
        var response = new GetResponse() { Customer = customer };
        return Task.FromResult(response);
    }

    public override Task<ListResponse> List(Empty request, ServerCallContext context)
    {
        var response = new ListResponse();
        response.Items.AddRange(_customers.OrderBy(x => x.Id));
        return Task.FromResult(response);
    }

    public override Task<OperationResultResponse> Insert(InsertRequest request, ServerCallContext context)
    {
        var customer = new Customer()
        {
            Id = _customers.Count == 0 ? 1 : _customers.Max(x => x.Id) + 1,
            Name = request.Name,
            Birth = request.Birth,
            Active = request.Active,
            Gender = request.Gender,
            CashBalance = request.CashBalance
        };

        _customers.Add(customer);

        var response = new OperationResultResponse()
        {
            Success = true,
            Reason = "Operation completed successfully"
        };

        return Task.FromResult(response);
    }

    public override Task<OperationResultResponse> Update(UpdateRequest request, ServerCallContext context)
    {
        var customer = _customers.Where(x => x.Id == request.Id).FirstOrDefault();

        if (customer == null)
        {
            var responseFailure = new OperationResultResponse()
            {
                Success = false,
                Reason = "Customer not found."
            };

            return Task.FromResult(responseFailure);
        }

        _customers.Remove(customer);

        customer = new Customer()
        {
            Id = request.Id,
            Name = request.Name,
            Birth = request.Birth,
            Active = request.Active,
            Gender = request.Gender,
            CashBalance = request.CashBalance
        };

        _customers.Add(customer);

        var response = new OperationResultResponse()
        {
            Success = true,
            Reason = "Operation completed successfully"
        };

        return Task.FromResult(response);
    }

    public override Task<OperationResultResponse> Delete(DeleteRequest request, ServerCallContext context)
    {
        var customer = _customers.Where(x => x.Id == request.Id).FirstOrDefault();

        if (customer == null)
        {
            var responseFailure = new OperationResultResponse()
            {
                Success = false,
                Reason = "Customer not found."
            };

            return Task.FromResult(responseFailure);
        }

        _customers.Remove(customer);

        var response = new OperationResultResponse()
        {
            Success = true,
            Reason = "Operation completed successfully"
        };

        return Task.FromResult(response);
    }
}