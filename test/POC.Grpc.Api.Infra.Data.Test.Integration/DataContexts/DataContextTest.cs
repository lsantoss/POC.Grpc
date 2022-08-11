﻿using NUnit.Framework;
using POC.Grpc.Api.Infra.Data.DataContexts;
using POC.Grpc.Api.Infra.Settings;
using POC.Grpc.Test.Tools.Base.Integration;
using POC.Grpc.Test.Tools.Extensions;
using System.Data;

namespace POC.Grpc.Api.Infra.Data.Test.Integration.DataContexts
{
    internal class DataContextTest : IntegrationTest
    {
        [Test]
        public void Contructor_Success()
        {
            var configuration = GetConfigurationApi();
            var connectionString = configuration["ConnectionString"];
            var appSettings = new AppSettings() { ConnectionString = connectionString };
            var dataContext = new DataContext(appSettings);

            TestContext.WriteLine(dataContext.ToJson());

            Assert.That(dataContext.Connection.State, Is.EqualTo(ConnectionState.Open));
        }

        [Test]
        public void Dispose_Success()
        {
            var configuration = GetConfigurationApi();
            var connectionString = configuration["ConnectionString"];
            var appSettings = new AppSettings() { ConnectionString = connectionString };
            var dataContext = new DataContext(appSettings);

            dataContext.Dispose();

            TestContext.WriteLine($"Connection: {dataContext.Connection.State}");

            Assert.That(dataContext.Connection.State, Is.EqualTo(ConnectionState.Closed));
        }
    }
}