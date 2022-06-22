using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;
using POC.Grpc.Lib.Contract.Proto.Common.MessagesRequest;
using POC.Grpc.Test.Tools.Base.Contract;
using POC.Grpc.Test.Tools.Extensions;
using System;
using System.Threading.Tasks;
using static POC.Grpc.Lib.Contract.Proto.Customers.Services.CustomerService;

namespace POC.Grpc.Api.Application.Test.Contract.Grpc
{
    internal class CustomerGrpcServiceTest : ContractTest
    {
        private readonly CustomerServiceClient _customerServiceClient;

        public CustomerGrpcServiceTest() => _customerServiceClient = GetServices<CustomerServiceClient>();

        [Test]
        public async Task GetAsync_Success()
        {
            try
            {
                var customer = MockData.CustomerResponse;

                var request = new GetByInt64IdRequest() { Id = customer.Id };
                var response = await _customerServiceClient.GetAsync(request);

                TestContext.WriteLine(response.Format());

                Assert.Multiple(() =>
                {
                    Assert.That(response.Id, Is.EqualTo(customer.Id));
                    Assert.That(response.Name, Is.EqualTo(customer.Name));
                    Assert.That(response.Age, Is.EqualTo(customer.Age));
                    Assert.That(response.Active, Is.EqualTo(customer.Active));
                    Assert.That(response.CashBalanceFloat, Is.EqualTo(customer.CashBalanceFloat));
                    Assert.That(response.CashBalanceDouble, Is.EqualTo(customer.CashBalanceDouble));
                    Assert.That(response.CashBalanceDecimal, Is.EqualTo(customer.CashBalanceDecimal));
                });
            }
            catch (Exception e)
            {
                Assert.Inconclusive(e.Message);
            }
        }

        [Test]
        public async Task GetAsync_Non_Registred_Customer_Success()
        {
            try
            {
                var request = new GetByInt64IdRequest() { Id = 0 };
                var response = await _customerServiceClient.GetAsync(request);

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
            catch (Exception e)
            {
                Assert.Inconclusive(e.Message);
            }
        }

        [Test]
        public async Task ListAsync_Success()
        {
            try
            {
                var customerList = MockData.CustomerListResponse;

                var response = await _customerServiceClient.ListAsync(new Empty());

                TestContext.WriteLine(response.Format());

                Assert.Multiple(() =>
                {
                    Assert.That(response.Customers[0].Id, Is.EqualTo(customerList.Customers[0].Id));
                    Assert.That(response.Customers[0].Name, Is.EqualTo(customerList.Customers[0].Name));
                    Assert.That(response.Customers[0].Age, Is.EqualTo(customerList.Customers[0].Age));
                    Assert.That(response.Customers[0].Active, Is.EqualTo(customerList.Customers[0].Active));
                    Assert.That(response.Customers[0].CashBalanceFloat, Is.EqualTo(customerList.Customers[0].CashBalanceFloat));
                    Assert.That(response.Customers[0].CashBalanceDouble, Is.EqualTo(customerList.Customers[0].CashBalanceDouble));
                    Assert.That(response.Customers[0].CashBalanceDecimal, Is.EqualTo(customerList.Customers[0].CashBalanceDecimal));

                    Assert.That(response.Customers[1].Id, Is.EqualTo(customerList.Customers[1].Id));
                    Assert.That(response.Customers[1].Name, Is.EqualTo(customerList.Customers[1].Name));
                    Assert.That(response.Customers[1].Age, Is.EqualTo(customerList.Customers[1].Age));
                    Assert.That(response.Customers[1].Active, Is.EqualTo(customerList.Customers[1].Active));
                    Assert.That(response.Customers[1].CashBalanceFloat, Is.EqualTo(customerList.Customers[1].CashBalanceFloat));
                    Assert.That(response.Customers[1].CashBalanceDouble, Is.EqualTo(customerList.Customers[1].CashBalanceDouble));
                    Assert.That(response.Customers[1].CashBalanceDecimal, Is.EqualTo(customerList.Customers[1].CashBalanceDecimal));

                    Assert.That(response.Customers[2].Id, Is.EqualTo(customerList.Customers[2].Id));
                    Assert.That(response.Customers[2].Name, Is.EqualTo(customerList.Customers[2].Name));
                    Assert.That(response.Customers[2].Age, Is.EqualTo(customerList.Customers[2].Age));
                    Assert.That(response.Customers[2].Active, Is.EqualTo(customerList.Customers[2].Active));
                    Assert.That(response.Customers[2].CashBalanceFloat, Is.EqualTo(customerList.Customers[2].CashBalanceFloat));
                    Assert.That(response.Customers[2].CashBalanceDouble, Is.EqualTo(customerList.Customers[2].CashBalanceDouble));
                    Assert.That(response.Customers[2].CashBalanceDecimal, Is.EqualTo(customerList.Customers[2].CashBalanceDecimal));
                });
            }
            catch (Exception e)
            {
                Assert.Inconclusive(e.Message);
            }
        }
    }
}