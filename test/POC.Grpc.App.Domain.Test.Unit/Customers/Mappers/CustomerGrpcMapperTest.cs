﻿using NUnit.Framework;
using POC.Grpc.App.Domain.Customers.Mappers;
using POC.Grpc.App.Domain.Customers.Models;
using POC.Grpc.Lib.Contract.Proto.Customers.MessagesResponse;
using POC.Grpc.Test.Tools.Base.Unit;
using POC.Grpc.Test.Tools.Constants;
using System.Collections.Generic;

namespace POC.Grpc.App.Domain.Test.Unit.Customers.Mappers
{
    internal class CustomerGrpcMapperTest : UnitTest
    {
        private const decimal NanoFactor = DecimalConstants.NanoFactor;

        [Test]
        public void MapToCustomerViewModel_NullParameter_ShouldGenerateNullValue()
        {
            //Act
            var result = CustomerGrpcMapper.MapToCustomerViewModel(null);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapToCustomerViewModel_NewObjectParameter_ShouldGenerateNullValue()
        {
            //Act
            var result = CustomerGrpcMapper.MapToCustomerViewModel(new CustomerResponse());

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapToCustomerViewModel_CustomerResponseParameter_ShouldGenerateCustomerViewModel()
        {
            //Arrange
            var customer = MockData.CustomerResponse;

            //Act
            var result = CustomerGrpcMapper.MapToCustomerViewModel(customer);

            //Assert
            Assert.Multiple(() =>
            {
                var cashBalanceDecimal = customer.CashBalanceDecimal.Units + customer.CashBalanceDecimal.Nanos / NanoFactor;

                Assert.That(result.Id, Is.EqualTo(customer.Id));
                Assert.That(result.Name, Is.EqualTo(customer.Name));
                Assert.That(result.Age, Is.EqualTo(customer.Age));
                Assert.That(result.Active, Is.EqualTo(customer.Active));
                Assert.That(result.CashBalanceFloat, Is.EqualTo(customer.CashBalanceFloat));
                Assert.That(result.CashBalanceDouble, Is.EqualTo(customer.CashBalanceDouble));
                Assert.That(result.CashBalanceDecimal, Is.EqualTo(cashBalanceDecimal));
                Assert.That(result, Is.InstanceOf<CustomerViewModel>());
            });
        }

        [Test]
        public void MapToListOfCustomerViewModel_NullParameter_ShouldGenerateListEmpty()
        {
            //Act
            var result = CustomerGrpcMapper.MapToListOfCustomerViewModel(null);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Empty);
                Assert.That(result, Is.InstanceOf<List<CustomerViewModel>>());
            });
        }

        [Test]
        public void MapToListOfCustomerViewModel_NewCustomerListResponseParameter_ShouldGenerateListEmpty()
        {
            //Act
            var result = CustomerGrpcMapper.MapToListOfCustomerViewModel(new CustomerListResponse());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Empty);
                Assert.That(result, Is.InstanceOf<List<CustomerViewModel>>());
            });
        }

        [Test]
        public void MapToListOfCustomerViewModel_CustomerListResponseParameter_ShouldGenerateListCustomerViewModel()
        {
            //Arrange
            var customerList = MockData.CustomerListResponse;

            //Act
            var result = CustomerGrpcMapper.MapToListOfCustomerViewModel(customerList);

            //Assert         
            Assert.Multiple(() =>
            {
                var cashBalanceDecimal = customerList.Customers[0].CashBalanceDecimal.Units + customerList.Customers[0].CashBalanceDecimal.Nanos / NanoFactor;

                Assert.That(result[0].Id, Is.EqualTo(customerList.Customers[0].Id));
                Assert.That(result[0].Name, Is.EqualTo(customerList.Customers[0].Name));
                Assert.That(result[0].Age, Is.EqualTo(customerList.Customers[0].Age));
                Assert.That(result[0].Active, Is.EqualTo(customerList.Customers[0].Active));
                Assert.That(result[0].CashBalanceFloat, Is.EqualTo(customerList.Customers[0].CashBalanceFloat));
                Assert.That(result[0].CashBalanceDouble, Is.EqualTo(customerList.Customers[0].CashBalanceDouble));
                Assert.That(result[0].CashBalanceDecimal, Is.EqualTo(cashBalanceDecimal));

                cashBalanceDecimal = customerList.Customers[1].CashBalanceDecimal.Units + customerList.Customers[1].CashBalanceDecimal.Nanos / NanoFactor;

                Assert.That(result[1].Id, Is.EqualTo(customerList.Customers[1].Id));
                Assert.That(result[1].Name, Is.EqualTo(customerList.Customers[1].Name));
                Assert.That(result[1].Age, Is.EqualTo(customerList.Customers[1].Age));
                Assert.That(result[1].Active, Is.EqualTo(customerList.Customers[1].Active));
                Assert.That(result[1].CashBalanceFloat, Is.EqualTo(customerList.Customers[1].CashBalanceFloat));
                Assert.That(result[1].CashBalanceDouble, Is.EqualTo(customerList.Customers[1].CashBalanceDouble));
                Assert.That(result[1].CashBalanceDecimal, Is.EqualTo(cashBalanceDecimal));

                cashBalanceDecimal = customerList.Customers[2].CashBalanceDecimal.Units + customerList.Customers[2].CashBalanceDecimal.Nanos / NanoFactor;

                Assert.That(result[2].Id, Is.EqualTo(customerList.Customers[2].Id));
                Assert.That(result[2].Name, Is.EqualTo(customerList.Customers[2].Name));
                Assert.That(result[2].Age, Is.EqualTo(customerList.Customers[2].Age));
                Assert.That(result[2].Active, Is.EqualTo(customerList.Customers[2].Active));
                Assert.That(result[2].CashBalanceFloat, Is.EqualTo(customerList.Customers[2].CashBalanceFloat));
                Assert.That(result[2].CashBalanceDouble, Is.EqualTo(customerList.Customers[2].CashBalanceDouble));
                Assert.That(result[2].CashBalanceDecimal, Is.EqualTo(cashBalanceDecimal));

                Assert.That(result, Is.InstanceOf<List<CustomerViewModel>>());
            });
        }
    }
}