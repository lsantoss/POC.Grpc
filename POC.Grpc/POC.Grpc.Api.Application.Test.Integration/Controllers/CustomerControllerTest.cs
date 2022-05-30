﻿using Newtonsoft.Json;
using NUnit.Framework;
using POC.Grpc.App.Domain.Customers.Models;
using POC.Grpc.Test.Base.Base;
using POC.Grpc.Test.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Application.Test.Integration.Controllers
{
    internal class CustomerControllerTest : BaseTest
    {
        private readonly HttpClient _httpClient;

        public CustomerControllerTest()
        {
            var configuration = GetConfigurationApi();
            _httpClient = new HttpClient { BaseAddress = new Uri(configuration["BaseUrlRest"]) };
        }

        [Test]
        public async Task Get_Success()
        {
            try
            {
                var customer = MocksTest.CustomerQueryResult;

                var responseString = await _httpClient.GetStringAsync($"v1/customers/{customer.Id}");
                var response = JsonConvert.DeserializeObject<CustomerViewModel>(responseString);

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
        public async Task Get_Non_Registred_Customer_Success()
        {
            try
            {
                var responseString = await _httpClient.GetStringAsync($"v1/customers/0");
                var response = JsonConvert.DeserializeObject<CustomerViewModel>(responseString);

                TestContext.WriteLine(response.Format());

                Assert.That(response, Is.Null);
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
                var customers = MocksTest.ListCustomerQueryResult;

                var responseString = await _httpClient.GetStringAsync($"v1/customers");
                var response = JsonConvert.DeserializeObject<List<CustomerViewModel>>(responseString);

                TestContext.WriteLine(response.Format());

                Assert.Multiple(() =>
                {
                    Assert.That(response[0].Id, Is.EqualTo(customers[0].Id));
                    Assert.That(response[0].Name, Is.EqualTo(customers[0].Name));
                    Assert.That(response[0].Age, Is.EqualTo(customers[0].Age));
                    Assert.That(response[0].Active, Is.EqualTo(customers[0].Active));
                    Assert.That(response[0].CashBalanceFloat, Is.EqualTo(customers[0].CashBalanceFloat));
                    Assert.That(response[0].CashBalanceDouble, Is.EqualTo(customers[0].CashBalanceDouble));
                    Assert.That(response[0].CashBalanceDecimal, Is.EqualTo(customers[0].CashBalanceDecimal));

                    Assert.That(response[1].Id, Is.EqualTo(customers[1].Id));
                    Assert.That(response[1].Name, Is.EqualTo(customers[1].Name));
                    Assert.That(response[1].Age, Is.EqualTo(customers[1].Age));
                    Assert.That(response[1].Active, Is.EqualTo(customers[1].Active));
                    Assert.That(response[1].CashBalanceFloat, Is.EqualTo(customers[1].CashBalanceFloat));
                    Assert.That(response[1].CashBalanceDouble, Is.EqualTo(customers[1].CashBalanceDouble));
                    Assert.That(response[1].CashBalanceDecimal, Is.EqualTo(customers[1].CashBalanceDecimal));

                    Assert.That(response[2].Id, Is.EqualTo(customers[2].Id));
                    Assert.That(response[2].Name, Is.EqualTo(customers[2].Name));
                    Assert.That(response[2].Age, Is.EqualTo(customers[2].Age));
                    Assert.That(response[2].Active, Is.EqualTo(customers[2].Active));
                    Assert.That(response[2].CashBalanceFloat, Is.EqualTo(customers[2].CashBalanceFloat));
                    Assert.That(response[2].CashBalanceDouble, Is.EqualTo(customers[2].CashBalanceDouble));
                    Assert.That(response[2].CashBalanceDecimal, Is.EqualTo(customers[2].CashBalanceDecimal));
                });
            }
            catch (Exception e)
            {
                Assert.Inconclusive(e.Message);
            }
        }
    }
}