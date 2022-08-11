using System;
using System.Data.SqlClient;

namespace POC.Grpc.Api.Infra.Data.DataContexts.Interfaces
{
    public interface IDataContext : IDisposable
    {
        SqlConnection Connection { get; }
    }
}