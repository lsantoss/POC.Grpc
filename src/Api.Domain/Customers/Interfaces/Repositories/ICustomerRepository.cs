using POC.Grpc.Api.Domain.Customers.Queries.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Domain.Customers.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerQueryResult> GetAsync(long id);
        Task<List<CustomerQueryResult>> ListAsync();
    }
}