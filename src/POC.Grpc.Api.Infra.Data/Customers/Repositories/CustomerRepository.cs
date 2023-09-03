using Dapper;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.Api.Infra.Data.Customers.Queries;
using POC.Grpc.Api.Infra.Data.DataContexts.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Infra.Data.Customers.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataContext _dataContext;
        private readonly DynamicParameters _parametrs = new();

        public CustomerRepository(IDataContext dataContext) => _dataContext = dataContext;

        public async Task<CustomerQueryResult> GetAsync(long id)
        {
            _parametrs.Add("Id", id, DbType.Int64);

            var result = await _dataContext.Connection.QueryAsync<CustomerQueryResult>(CustomerQueries.Get, _parametrs);
            return result.FirstOrDefault();
        }

        public async Task<List<CustomerQueryResult>> ListAsync()
        {
            var result = await _dataContext.Connection.QueryAsync<CustomerQueryResult>(CustomerQueries.List);
            return result.ToList();
        }
    }
}