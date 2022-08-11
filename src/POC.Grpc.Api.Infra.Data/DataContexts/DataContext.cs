using POC.Grpc.Api.Infra.Data.DataContexts.Interfaces;
using POC.Grpc.Api.Infra.Settings;
using System.Data;
using System.Data.SqlClient;

namespace POC.Grpc.Api.Infra.Data.DataContexts
{
    public class DataContext : IDataContext
    {
        public SqlConnection Connection { get; }

        public DataContext(AppSettings appSettings)
        {
            Connection = new SqlConnection(appSettings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}