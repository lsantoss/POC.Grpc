using NUnit.Framework;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using POC.Grpc.Test.Base.Base;
using POC.Grpc.Test.Base.Extensions;

namespace POC.Grpc.Api.Infra.Data.Test.Unit.Repositories
{
    internal class CustomerRepositoryTest : BaseTest
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRepositoryTest() => _customerRepository = GetServices<ICustomerRepository>();

        [Test]
        public void Get_Success()
        {
            var customer = MocksTest.CustomerQueryResult;

            var result = _customerRepository.Get(customer.Id);

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

        [Test]
        public void Get_Non_Registred_Customer_Success()
        {
            var result = _customerRepository.Get(0);

            TestContext.WriteLine(result.Format());

            Assert.That(result, Is.Null);
        }

        [Test]
        public void List_Success()
        {
            var customers = MocksTest.ListCustomerQueryResult;

            var result = _customerRepository.List();

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
    }
}