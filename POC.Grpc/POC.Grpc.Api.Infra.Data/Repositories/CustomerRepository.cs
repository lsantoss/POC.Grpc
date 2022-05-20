using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using POC.Grpc.Api.Domain.Customers.Queries.Result;
using System.Collections.Generic;
using System.Linq;

namespace POC.Grpc.Api.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerQueryResult Get(long id) => Customers.FirstOrDefault(x => x.Id == id);

        public List<CustomerQueryResult> List() => Customers;

        private static readonly List<CustomerQueryResult> Customers = new()
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
    }
}