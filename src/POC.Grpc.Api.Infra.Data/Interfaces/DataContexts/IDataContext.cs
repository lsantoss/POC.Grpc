using System;
using System.Data.SqlClient;

namespace POC.Grpc.Api.Infra.Data.Interfaces.DataContexts
{
    public interface IDataContext : IDisposable
    {
        SqlConnection Connection { get; }
    }
}