using Dapper;
using NUnit.Framework;
using POC.Grpc.Test.Tools.Mocks;
using System;
using System.Data.SqlClient;
using System.IO;

namespace POC.Grpc.Test.Tools.Base
{
    [TestFixture]
    public class IntegrationTest : BaseTest
    {
        private readonly string _connectionString;
        private readonly string _connectionStringReal;
        private readonly string _scriptCreateDatabasePath;
        private readonly string _scriptCreateTablesPath;
        private readonly string _scriptDropTablesPath;

        public IntegrationTest() : base()
        {
            var configuration = GetConfigurationApi();
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            _connectionString = configuration["ConnectionString"];
            _connectionStringReal = configuration["ConnectionStringReal"];
            _scriptCreateDatabasePath = $@"{baseDirectory}\Sql\CreateDatabase.sql";
            _scriptCreateTablesPath = $@"{baseDirectory}\Sql\CreateTables.sql";
            _scriptDropTablesPath = $@"{baseDirectory}\Sql\DropTables.sql";
        }

        [OneTimeSetUp]
        protected override void OneTimeSetUp() => InitializeData();

        [OneTimeTearDown]
        protected override void OneTimeTearDown() => ClearData();

        [SetUp]
        protected override void SetUp() => InitializeData();

        [TearDown]
        protected override void TearDown() => ClearData();

        private void InitializeData()
        {
            MockData = new MockData();
            PrepareDatabase();
        }

        private void ClearData()
        {
            MockData = null;
            DestroyDatabase();
        }

        private void PrepareDatabase()
        {
            try
            {
                using (var streamReader = new StreamReader(_scriptCreateDatabasePath))
                {
                    using (var connection = new SqlConnection(_connectionStringReal))
                    {
                        connection.Execute(streamReader.ReadToEnd());
                    }
                }

                using (var streamReader = new StreamReader(_scriptCreateTablesPath))
                {
                    var scripts = streamReader.ReadToEnd().Split(
                        new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                    using (var connection = new SqlConnection(_connectionString))
                    {
                        foreach (var script in scripts)
                            connection.Execute(script);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error running scripts to prepare the test database: {ex.Message}");
            }
        }

        private void DestroyDatabase()
        {
            try
            {
                using (var streamReader = new StreamReader(_scriptDropTablesPath))
                {
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        connection.Execute(streamReader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error running scripts to destroy test database: {ex.Message}");
            }
        }
    }
}