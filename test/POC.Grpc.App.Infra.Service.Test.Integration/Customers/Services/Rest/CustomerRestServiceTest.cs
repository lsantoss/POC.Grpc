﻿using NUnit.Framework;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Rest;
using POC.Grpc.Test.Tools.Base.Integration;
using System.Net.Http;
using System.Threading.Tasks;

namespace POC.Grpc.App.Infra.Service.Test.Integration.Customers.Services.Rest
{
    internal class CustomerRestServiceTest : IntegrationTest
    {
        private readonly ICustomerRestService _customerRestService;

        public CustomerRestServiceTest() => _customerRestService = GetServices<ICustomerRestService>();

        [Test]
        public async Task GetAsync_RegistredCustomer_ShouldGetCustomerRecord()
        {
            try
            {
                //Arrange
                var customer = MockData.CustomerViewModel;

                //Act
                var result = await _customerRestService.GetAsync(customer.Id);

                //Assert
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
            catch (HttpRequestException e)
            {
                //Assert
                Assert.Inconclusive(e.Message);
            }
        }

        [Test]
        public async Task GetAsync_NonRegistredCustomer_ShouldReturnNull()
        {
            try
            {
                //Act
                var result = await _customerRestService.GetAsync(0);

                //Assert
                Assert.That(result, Is.Null);
            }
            catch (HttpRequestException e)
            {
                //Assert
                Assert.Inconclusive(e.Message);
            }
        }

        [Test]
        public async Task ListAsync_ShouldReturnListOfCustomers()
        {
            try
            {
                //Arrange
                var customers = MockData.ListCustomerViewModel;

                //Act
                var result = await _customerRestService.ListAsync();

                //Assert
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
            catch (HttpRequestException e)
            {
                //Assert
                Assert.Inconclusive(e.Message);
            }
        }
    }
}