using Dapper;
using POC.Grpc.Api.Domain.Core.Settings;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.Api.Infra.Data.Repositories.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppSettings _appSettings;
        private readonly DynamicParameters _parametrs = new();

        public CustomerRepository(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<CustomerQueryResult> GetAsync(long id)
        {
            _parametrs.Add("Id", id, DbType.Int64);

            using var connection = new SqlConnection(_appSettings.ConnectionString);

            return (await connection.QueryAsync<CustomerQueryResult>(CustomerQueries.Get, _parametrs)).FirstOrDefault();
        }

        public async Task<List<CustomerQueryResult>> ListAsync()
        {
            using var connection = new SqlConnection(_appSettings.ConnectionString);

            return (await connection.QueryAsync<CustomerQueryResult>(CustomerQueries.List)).ToList();
        }
    }
}