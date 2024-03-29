﻿using NUnit.Framework;
using POC.Grpc.Api.Infra.Data.DataContexts;
using POC.Grpc.Api.Infra.Settings;
using POC.Grpc.Test.Tools.Base.Integration;
using System.Data;

namespace POC.Grpc.Api.Infra.Data.Test.Integration.DataContexts
{
    internal class DataContextTest : IntegrationTest
    {
        [Test]
        public void Contructor_ConnectionMustBeOpen()
        {
            //Arrange
            var configuration = GetConfigurationApi();
            var connectionString = configuration["ConnectionString"];
            var appSettings = new AppSettings() { ConnectionString = connectionString };

            //Act
            var dataContext = new DataContext(appSettings);

            //Assert
            Assert.That(dataContext.Connection.State, Is.EqualTo(ConnectionState.Open));
        }

        [Test]
        public void Dispose_ConnectionMustBeClosed()
        {
            //Arrange
            var configuration = GetConfigurationApi();
            var connectionString = configuration["ConnectionString"];
            var appSettings = new AppSettings() { ConnectionString = connectionString };
            var dataContext = new DataContext(appSettings);

            //Act
            dataContext.Dispose();

            TestContext.WriteLine($"Connection: {dataContext.Connection.State}");

            //Assert
            Assert.That(dataContext.Connection.State, Is.EqualTo(ConnectionState.Closed));
        }
    }
}