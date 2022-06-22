using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.App.Domain.Customers.Models;
using POC.Grpc.Lib.Contract.Mappers;
using POC.Grpc.Lib.Contract.Proto.Customers.MessagesResponse;
using System.Collections.Generic;

namespace POC.Grpc.Test.Tools.Mocks.Customers
{
    public static class CustomerMock
    {
        public static CustomerQueryResult GetCustomerQueryResult() => new()
        {
            Id = 1,
            Name = "Lucas",
            Age = 26,
            Active = true,
            CashBalanceFloat = 2502.35f,
            CashBalanceDouble = 2502.35,
            CashBalanceDecimal = 2502.35m
        };

        public static List<CustomerQueryResult> GetListCustomerQueryResult() => new()
        {
            new CustomerQueryResult()
            {
                Id = 1,
                Name = "Lucas",
                Age = 26,
                Active = true,
                CashBalanceFloat = 2502.35f,
                CashBalanceDouble = 2502.35,
                CashBalanceDecimal = 2502.35m,
            },
            new CustomerQueryResult()
            {
                Id = 2,
                Name = "Steh",
                Age = 29,
                Active = true,
                CashBalanceFloat = 7256.12f,
                CashBalanceDouble = 7256.12,
                CashBalanceDecimal = 7256.12m,
            },
            new CustomerQueryResult()
            {
                Id = 3,
                Name = "Mattheus",
                Age = 26,
                Active = false,
                CashBalanceFloat = 4895.11f,
                CashBalanceDouble = 4895.11,
                CashBalanceDecimal = 4895.11m,
            }
        };

        public static CustomerViewModel GetCustomerViewModel() => new()
        {
            Id = 1,
            Name = "Lucas",
            Age = 26,
            Active = true,
            CashBalanceFloat = 2502.35f,
            CashBalanceDouble = 2502.35,
            CashBalanceDecimal = 2502.35m
        };

        public static List<CustomerViewModel> GetListCustomerViewModel() => new()
        {
            new CustomerViewModel()
            {
                Id = 1,
                Name = "Lucas",
                Age = 26,
                Active = true,
                CashBalanceFloat = 2502.35f,
                CashBalanceDouble = 2502.35,
                CashBalanceDecimal = 2502.35m,
            },
            new CustomerViewModel()
            {
                Id = 2,
                Name = "Steh",
                Age = 29,
                Active = true,
                CashBalanceFloat = 7256.12f,
                CashBalanceDouble = 7256.12,
                CashBalanceDecimal = 7256.12m,
            },
            new CustomerViewModel()
            {
                Id = 3,
                Name = "Mattheus",
                Age = 26,
                Active = false,
                CashBalanceFloat = 4895.11f,
                CashBalanceDouble = 4895.11,
                CashBalanceDecimal = 4895.11m,
            }
        };

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