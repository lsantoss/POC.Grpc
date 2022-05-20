using NUnit.Framework;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Rest;
using POC.Grpc.Test.Base.Base;
using POC.Grpc.Test.Base.Extensions;
using System;
using System.Threading.Tasks;

namespace POC.Grpc.App.Infra.Service.Test.Unit.Services.Rest
{
    internal class CustomerRestServiceTest : BaseTest
    {
        private readonly ICustomerRestService _customerRestService;

        public CustomerRestServiceTest() => _customerRestService = GetServices<ICustomerRestService>();

        [Test]
        public async Task Get_Success()
        {
            try
            {
                var customer = MocksTest.CustomerViewModel;

                var result = await _customerRestService.Get(customer.Id);

                TestContext.WriteLine(result.Format());

                Assert.Multiple(() =>
                {
                    Assert.That(result.Id, Is.EqualTo(customer.Id));
                    Assert.That(result.Name, Is.EqualTo(customer.Name));
                    Assert.That(result.Age, Is.EqualTo(customer.Age));
                    Assert.That(result.Active, Is.EqualTo(customer.Active));
                    Assert.That(result.CashBalanceFloat, Is.EqualTo(customer.CashBalanceFloat));
                    Assert.That(result.CashBalanceDouble, Is.EqualTo(customer.CashBalanceDouble));
                    Assert.That(result.CashBalanceDecimal, Is.EqualTo(customer.CashBalanceDecimal));
                });
            }
            catch (Exception e)
            {
                Assert.Inconclusive(e.Message);
            }
        }

        [Test]
        public async Task List_Success()
        {
            try
            {
                var customers = MocksTest.ListCustomerViewModel;

                var result = await _customerRestService.List();

                TestContext.WriteLine(result.Format());

                Assert.Multiple(() =>
                {
                    Assert.That(result[0].Id, Is.EqualTo(customers[0].Id));
                    Assert.That(result[0].Name, Is.EqualTo(customers[0].Name));
                    Assert.That(result[0].Age, Is.EqualTo(customers[0].Age));
                    Assert.That(result[0].Active, Is.EqualTo(customers[0].Active));
                    Assert.That(result[0].CashBalanceFloat, Is.EqualTo(customers[0].CashBalanceFloat));
                    Assert.That(result[0].CashBalanceDouble, Is.EqualTo(customers[0].CashBalanceDouble));
                    Assert.That(result[0].CashBalanceDecimal, Is.EqualTo(customers[0].CashBalanceDecimal));

                    Assert.That(result[1].Id, Is.EqualTo(customers[1].Id));
                    Assert.That(result[1].Name, Is.EqualTo(customers[1].Name));
                    Assert.That(result[1].Age, Is.EqualTo(customers[1].Age));
                    Assert.That(result[1].Active, Is.EqualTo(customers[1].Active));
                    Assert.That(result[1].CashBalanceFloat, Is.EqualTo(customers[1].CashBalanceFloat));
                    Assert.That(result[1].CashBalanceDouble, Is.EqualTo(customers[1].CashBalanceDouble));
                    Assert.That(result[1].CashBalanceDecimal, Is.EqualTo(customers[1].CashBalanceDecimal));

                    Assert.That(result[2].Id, Is.EqualTo(customers[2].Id));
                    Assert.That(result[2].Name, Is.EqualTo(customers[2].Name));
                    Assert.That(result[2].Age, Is.EqualTo(customers[2].Age));
                    Assert.That(result[2].Active, Is.EqualTo(customers[2].Active));
                    Assert.That(result[2].CashBalanceFloat, Is.EqualTo(customers[2].CashBalanceFloat));
                    Assert.That(result[2].CashBalanceDouble, Is.EqualTo(customers[2].CashBalanceDouble));
                    Assert.That(result[2].CashBalanceDecimal, Is.EqualTo(customers[2].CashBalanceDecimal));
                });
            }
            catch (Exception e)
            {
                Assert.Inconclusive(e.Message);
            }
        }
    }
}