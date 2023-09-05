using Newtonsoft.Json;
using NUnit.Framework;
using POC.Grpc.Api.Application.Controllers;
using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.Test.Tools.Base.Integration;
using POC.Grpc.Test.Tools.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Application.Test.Integration.Controllers
{
    internal class CustomerControllerTest : IntegrationTest
    {
        private readonly CustomerController customerController;

        public CustomerControllerTest() => customerController = GetServices<CustomerController>();

        [Test]
        public async Task GetAsync_RegistredCustomer_ShouldGetCustomerRecord()
        {
            //Arrange
            var customer = MockData.CustomerQueryResult;

            //Act
            var actionResult = await customerController.GetAsync(customer.Id);
            var actionResultJson = JsonConvert.SerializeObject(actionResult);
            var response = JsonConvert.DeserializeObject<ControllerResponse<CustomerQueryResult>>(actionResultJson);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(200));
                Assert.That(response.Value.Id, Is.EqualTo(customer.Id));
                Assert.That(response.Value.Name, Is.EqualTo(customer.Name));
                Assert.That(response.Value.Age, Is.EqualTo(customer.Age));
                Assert.That(response.Value.Active, Is.EqualTo(customer.Active));
                Assert.That(response.Value.CashBalanceFloat, Is.EqualTo(customer.CashBalanceFloat));
                Assert.That(response.Value.CashBalanceDouble, Is.EqualTo(customer.CashBalanceDouble));
                Assert.That(response.Value.CashBalanceDecimal, Is.EqualTo(customer.CashBalanceDecimal));
            });
        }

        [Test]
        public async Task GetAsync_NonRegistredCustomer_ShouldReturnNull()
        {
            //Act
            var actionResult = await customerController.GetAsync(0);
            var actionResultJson = JsonConvert.SerializeObject(actionResult);
            var response = JsonConvert.DeserializeObject<ControllerResponse<CustomerQueryResult>>(actionResultJson);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(204));
                Assert.That(response.Value, Is.Null);
            });
        }

        [Test]
        public async Task ListAsync_ShouldReturnListOfCustomers()
        {
            //Arrange
            var customers = MockData.ListCustomerQueryResult;

            //Act
            var actionResult = await customerController.ListAsync();
            var actionResultJson = JsonConvert.SerializeObject(actionResult);
            var response = JsonConvert.DeserializeObject<ControllerResponse<List<CustomerQueryResult>>>(actionResultJson);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(200));

                Assert.That(response.Value[0].Id, Is.EqualTo(customers[0].Id));
                Assert.That(response.Value[0].Name, Is.EqualTo(customers[0].Name));
                Assert.That(response.Value[0].Age, Is.EqualTo(customers[0].Age));
                Assert.That(response.Value[0].Active, Is.EqualTo(customers[0].Active));
                Assert.That(response.Value[0].CashBalanceFloat, Is.EqualTo(customers[0].CashBalanceFloat));
                Assert.That(response.Value[0].CashBalanceDouble, Is.EqualTo(customers[0].CashBalanceDouble));
                Assert.That(response.Value[0].CashBalanceDecimal, Is.EqualTo(customers[0].CashBalanceDecimal));

                Assert.That(response.Value[1].Id, Is.EqualTo(customers[1].Id));
                Assert.That(response.Value[1].Name, Is.EqualTo(customers[1].Name));
                Assert.That(response.Value[1].Age, Is.EqualTo(customers[1].Age));
                Assert.That(response.Value[1].Active, Is.EqualTo(customers[1].Active));
                Assert.That(response.Value[1].CashBalanceFloat, Is.EqualTo(customers[1].CashBalanceFloat));
                Assert.That(response.Value[1].CashBalanceDouble, Is.EqualTo(customers[1].CashBalanceDouble));
                Assert.That(response.Value[1].CashBalanceDecimal, Is.EqualTo(customers[1].CashBalanceDecimal));

                Assert.That(response.Value[2].Id, Is.EqualTo(customers[2].Id));
                Assert.That(response.Value[2].Name, Is.EqualTo(customers[2].Name));
                Assert.That(response.Value[2].Age, Is.EqualTo(customers[2].Age));
                Assert.That(response.Value[2].Active, Is.EqualTo(customers[2].Active));
                Assert.That(response.Value[2].CashBalanceFloat, Is.EqualTo(customers[2].CashBalanceFloat));
                Assert.That(response.Value[2].CashBalanceDouble, Is.EqualTo(customers[2].CashBalanceDouble));
                Assert.That(response.Value[2].CashBalanceDecimal, Is.EqualTo(customers[2].CashBalanceDecimal));
            });
        }
    }
}