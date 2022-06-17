using POC.Grpc.Api.Domain.Customers.Queries.Result;
using System.Collections.Generic;

namespace POC.Grpc.Api.Domain.Customers.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        CustomerQueryResult Get(long id);
        List<CustomerQueryResult> List();
    }
}