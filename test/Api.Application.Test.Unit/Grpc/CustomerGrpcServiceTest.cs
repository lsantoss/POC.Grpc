using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;
using POC.Grpc.Api.Application.Grpc;
using POC.Grpc.Lib.Contract.Proto.Common.MessagesRequest;
using POC.Grpc.Test.Tools.Base;
using POC.Grpc.Test.Tools.Constants;
using POC.Grpc.Test.Tools.Extensions;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Application.Test.Unit.Grpc
{
    internal class CustomerGrpcServiceTest : UnitTest
    {
        private const decimal NanoFactor = DecimalConstants.NanoFactor;

        private readonly CustomerGrpcService customerGrpcService;

        public CustomerGrpcServiceTest() => customerGrpcService = GetServices<CustomerGrpcService>();

        [Test]
        public async Task GetAsync_Success()
        {
            var customer = MockData.CustomerQueryResult;

            var request = new GetByInt64IdRequest() { Id = customer.Id };
            var response = await customerGrpcService.Get(request, null);

            TestContext.WriteLine(response.Format());

            Assert.Multiple(() =>
            {
                var units = decimal.ToInt64(customer.CashBalanceDecimal);
                var nanos = decimal.ToInt32((customer.CashBalanceDecimal - units) * NanoFactor);

                Assert.That(response.Id, Is.EqualTo(customer.Id));
                Assert.That(response.Name, Is.EqualTo(customer.Name));
                Assert.That(response.Age, Is.EqualTo(customer.Age));
                Assert.That(response.Active, Is.EqualTo(customer.Active));
                Assert.That(response.CashBalanceFloat, Is.EqualTo(customer.CashBalanceFloat));
                Assert.That(response.CashBalanceDouble, Is.EqualTo(customer.CashBalanceDouble));
                Assert.That(response.CashBalanceDecimal.Units, Is.EqualTo(units));
                Assert.That(response.CashBalanceDecimal.Nanos, Is.EqualTo(nanos));
            });
        }

        [Test]
        public async Task GetAsync_Non_Registred_Customer_Success()
        {
            var request = new GetByInt64IdRequest() { Id = 0 };
            var response = await customerGrpcService.Get(request, null);

            TestContext.WriteLine(response.Format());

            Assert.Multiple(() =>
            {
                Assert.That(response.Id, Is.Zero);
                Assert.That(response.Name, Is.Empty);
                Assert.That(response.Age, Is.Zero);
                Assert.That(response.Active, Is.False);
                Assert.That(response.CashBalanceFloat, Is.Zero);
                Assert.That(response.CashBalanceDouble, Is.Zero);
                Assert.That(response.CashBalanceDecimal, Is.Null);
            });
        }

        [Test]
        public async Task ListAsync_Success()
        {
            var customers = MockData.ListCustomerQueryResult;

            var response = await customerGrpcService.List(new Empty(), null);

            TestContext.WriteLine(response.Format());
                        
            Assert.Multiple(() =>
            {
                var units = decimal.ToInt64(customers[0].CashBalanceDecimal);
                var nanos = decimal.ToInt32((customers[0].CashBalanceDecimal - units) * NanoFactor);

                Assert.That(response.Customers[0].Id, Is.EqualTo(customers[0].Id));
                Assert.That(response.Customers[0].Name, Is.EqualTo(customers[0].Name));
                Assert.That(response.Customers[0].Age, Is.EqualTo(customers[0].Age));
                Assert.That(response.Customers[0].Active, Is.EqualTo(customers[0].Active));
                Assert.That(response.Customers[0].CashBalanceFloat, Is.EqualTo(customers[0].CashBalanceFloat));
                Assert.That(response.Customers[0].CashBalanceDouble, Is.EqualTo(customers[0].CashBalanceDouble));
                Assert.That(response.Customers[0].CashBalanceDecimal.Units, Is.EqualTo(units));
                Assert.That(response.Customers[0].CashBalanceDecimal.Nanos, Is.EqualTo(nanos));

                units = decimal.ToInt64(customers[1].CashBalanceDecimal);
                nanos = decimal.ToInt32((customers[1].CashBalanceDecimal - units) * NanoFactor);

                Assert.That(response.Customers[1].Id, Is.EqualTo(customers[1].Id));
                Assert.That(response.Customers[1].Name, Is.EqualTo(customers[1].Name));
                Assert.That(response.Customers[1].Age, Is.EqualTo(customers[1].Age));
                Assert.That(response.Customers[1].Active, Is.EqualTo(customers[1].Active));
                Assert.That(response.Customers[1].CashBalanceFloat, Is.EqualTo(customers[1].CashBalanceFloat));
                Assert.That(response.Customers[1].CashBalanceDouble, Is.EqualTo(customers[1].CashBalanceDouble));
                Assert.That(response.Customers[1].CashBalanceDecimal.Units, Is.EqualTo(units));
                Assert.That(response.Customers[1].CashBalanceDecimal.Nanos, Is.EqualTo(nanos));

                units = decimal.ToInt64(customers[2].CashBalanceDecimal);
                nanos = decimal.ToInt32((customers[2].CashBalanceDecimal - units) * NanoFactor);

                Assert.That(response.Customers[2].Id, Is.EqualTo(customers[2].Id));
                Assert.That(response.Customers[2].Name, Is.EqualTo(customers[2].Name));
                Assert.That(response.Customers[2].Age, Is.EqualTo(customers[2].Age));
                Assert.That(response.Customers[2].Active, Is.EqualTo(customers[2].Active));
                Assert.That(response.Customers[2].CashBalanceFloat, Is.EqualTo(customers[2].CashBalanceFloat));
                Assert.That(response.Customers[2].CashBalanceDouble, Is.EqualTo(customers[2].CashBalanceDouble));
                Assert.That(response.Customers[2].CashBalanceDecimal.Units, Is.EqualTo(units));
                Assert.That(response.Customers[2].CashBalanceDecimal.Nanos, Is.EqualTo(nanos));
            });
        }
    }
}