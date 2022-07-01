using POC.Grpc.App.Domain.Customers.Models;
using System.Collections.Generic;

namespace POC.Grpc.Test.Tools.Mocks.Customers.ViewModels
{
    public static class CustomerViewModelMock
    {
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
    }
}
