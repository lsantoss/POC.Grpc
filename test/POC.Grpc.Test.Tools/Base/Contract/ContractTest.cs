using NUnit.Framework;
using POC.Grpc.Test.Tools.Base.Common;
using System;
using System.Net.Http;

namespace POC.Grpc.Test.Tools.Base.Contract
{
    [TestFixture]
    public class ContractTest : DatabaseTest
    {
        protected readonly HttpClient _httpClient;

        public ContractTest() : base()
        {
            var configuration = GetConfigurationApi();
            _httpClient = new HttpClient { BaseAddress = new Uri(configuration["BaseUrlRest"]) };
        }

        [OneTimeSetUp]
        protected override void OneTimeSetUp() => base.OneTimeSetUp();

        [OneTimeTearDown]
        protected override void OneTimeTearDown() => base.OneTimeTearDown();

        [SetUp]
        protected override void SetUp() => base.SetUp();

        [TearDown]
        protected override void TearDown() => base.TearDown();
    }
}