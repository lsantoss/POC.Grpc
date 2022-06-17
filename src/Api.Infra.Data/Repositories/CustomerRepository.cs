using Dapper;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.Api.Infra.Data.DataContexts;
using POC.Grpc.Api.Infra.Data.Repositories.Queries;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;
        private readonly DynamicParameters _parametrs = new();

        public CustomerRepository(DataContext dataContext) => _dataContext = dataContext;

        public async Task<CustomerQueryResult> GetAsync(long id)
        {
            _parametrs.Add("Id", id, DbType.Int64);
            return (await _dataContext.Connection.QueryAsync<CustomerQueryResult>(CustomerQueries.Get, _parametrs)).FirstOrDefault();
        }

        public async Task<List<CustomerQueryResult>> ListAsync()
        {
            return (await _dataContext.Connection.QueryAsync<CustomerQueryResult>(CustomerQueries.List)).ToList();
        }
    }
}