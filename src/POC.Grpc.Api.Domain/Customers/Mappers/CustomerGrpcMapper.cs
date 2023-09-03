using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.Lib.Contract.Mappers;
using POC.Grpc.Lib.Contract.Proto.Customers.MessagesResponse;
using System.Collections.Generic;

namespace POC.Grpc.Api.Domain.Customers.Mappers
{
    public static class CustomerGrpcMapper
    {
        public static CustomerResponse MapToCustomerResponse(this CustomerQueryResult customer) => customer switch
        {
            null => new CustomerResponse(),
            _ => new CustomerResponse()
            {
                Id = customer.Id,
                Name = customer.Name ?? string.Empty,
                Age = customer.Age,
                Active = customer.Active,
                CashBalanceFloat = customer.CashBalanceFloat,
                CashBalanceDouble = customer.CashBalanceDouble,
                CashBalanceDecimal = DecimalGrpcMapper.Map(customer.CashBalanceDecimal)
            }
        };

        public static CustomerListResponse MapToCustomerListResponse(this List<CustomerQueryResult> customers)
        {
            var customerListResponse = new CustomerListResponse();

            if (customers == null || (customers?.Count) <= 0)
                return customerListResponse;

            foreach (var customer in customers)
                customerListResponse.Customers.Add(customer.MapToCustomerResponse());

            return customerListResponse;
        }
    }
}