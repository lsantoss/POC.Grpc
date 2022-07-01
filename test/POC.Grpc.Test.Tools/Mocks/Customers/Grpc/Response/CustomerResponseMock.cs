using POC.Grpc.Lib.Contract.Mappers;
using POC.Grpc.Lib.Contract.Proto.Customers.MessagesResponse;

namespace POC.Grpc.Test.Tools.Mocks.Customers.Grpc.Response
{
    public static class CustomerResponseMock
    {
        public static CustomerResponse GetCustomerResponse() => new()
        {
            Id = 1,
            Name = "Lucas",
            Age = 26,
            Active = true,
            CashBalanceFloat = 2502.35f,
            CashBalanceDouble = 2502.35,
            CashBalanceDecimal = DecimalGrpcMapper.Map(2502.35m)
        };

        public static CustomerListResponse GetListCustomerResponse()
        {
            var customerListResponse = new CustomerListResponse();

            customerListResponse.Customers.Add(new CustomerResponse()
            {
                Id = 1,
                Name = "Lucas",
                Age = 26,
                Active = true,
                CashBalanceFloat = 2502.35f,
                CashBalanceDouble = 2502.35,
                CashBalanceDecimal = DecimalGrpcMapper.Map(2502.35m),
            });

            customerListResponse.Customers.Add(new CustomerResponse()
            {
                Id = 2,
                Name = "Steh",
                Age = 29,
                Active = true,
                CashBalanceFloat = 7256.12f,
                CashBalanceDouble = 7256.12,
                CashBalanceDecimal = DecimalGrpcMapper.Map(7256.12m),
            });

            customerListResponse.Customers.Add(new CustomerResponse()
            {
                Id = 3,
                Name = "Mattheus",
                Age = 26,
                Active = false,
                CashBalanceFloat = 4895.11f,
                CashBalanceDouble = 4895.11,
                CashBalanceDecimal = DecimalGrpcMapper.Map(4895.11m),
            });

            return customerListResponse;
        }
    }
}