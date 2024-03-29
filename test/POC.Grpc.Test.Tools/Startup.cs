﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using DependencyInjectionExtensionApi = POC.Grpc.Api.Application.Extensions.DependencyInjectionExtension;
using DependencyInjectionExtensionApp = POC.Grpc.App.Application.Extensions.DependencyInjectionExtension;
using DependencyInjectionExtensionTest = POC.Grpc.Test.Tools.Extensions.DependencyInjectionExtension;

namespace POC.Grpc.Test.Tools
{
    [TestFixture]
    public class Startup
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configurationApi;
        private readonly IConfiguration _configurationApp;

        public Startup()
        {
            _services = new ServiceCollection();

            _configurationApi = new ConfigurationBuilder().AddJsonFile("appsettings-api.json", true, false).AddEnvironmentVariables().Build();
            _configurationApp = new ConfigurationBuilder().AddJsonFile("appsettings-app.json", true, false).AddEnvironmentVariables().Build();

            _services = DependencyInjectionExtensionApi.AddDependencies(_services, _configurationApi);
            _services = DependencyInjectionExtensionApp.AddDependencies(_services, _configurationApp);
            _services = DependencyInjectionExtensionTest.AddDependencies(_services);

            _serviceProvider = _services.BuildServiceProvider();
        }

        protected IConfiguration GetConfigurationApi() => _configurationApi;
        protected IConfiguration GetConfigurationApp() => _configurationApp;
        protected T GetServices<T>() => (T)_serviceProvider.GetService(typeof(T));
    }
}