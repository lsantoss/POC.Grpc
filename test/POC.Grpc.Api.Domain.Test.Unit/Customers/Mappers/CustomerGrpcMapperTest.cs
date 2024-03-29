﻿using NUnit.Framework;
using POC.Grpc.Api.Domain.Customers.Mappers;
using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.Lib.Contract.Proto.Customers.MessagesResponse;
using POC.Grpc.Test.Tools.Base.Unit;
using POC.Grpc.Test.Tools.Constants;
using System.Collections.Generic;

namespace POC.Grpc.Api.Domain.Test.Unit.Customers.Mappers
{
    internal class CustomerGrpcMapperTest : UnitTest
    {
        private const decimal NanoFactor = DecimalConstants.NanoFactor;

        [Test]
        public void MapToCustomerResponse_NullParameter_ShouldGenerateCustomerResponseWithDefaultValues()
        {
            //Act
            var result = CustomerGrpcMapper.MapToCustomerResponse(null);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.Zero);
                Assert.That(result.Name, Is.Empty);
                Assert.That(result.Age, Is.Zero);
                Assert.That(result.Active, Is.False);
                Assert.That(result.CashBalanceFloat, Is.Zero);
                Assert.That(result.CashBalanceDouble, Is.Zero);
                Assert.That(result.CashBalanceDecimal, Is.Null);
                Assert.That(result, Is.InstanceOf<CustomerResponse>());
            });
        }

        [Test]
        public void MapToCustomerResponse_NewObjectParameter_ShouldGenerateCustomerResponseWithDefaultValues()
        {
            //Act
            var result = CustomerGrpcMapper.MapToCustomerResponse(new CustomerQueryResult());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.Zero);
                Assert.That(result.Name, Is.Empty);
                Assert.That(result.Age, Is.Zero);
                Assert.That(result.Active, Is.False);
                Assert.That(result.CashBalanceFloat, Is.Zero);
                Assert.That(result.CashBalanceDouble, Is.Zero);
                Assert.That(result.CashBalanceDecimal.Units, Is.Zero);
                Assert.That(result.CashBalanceDecimal.Nanos, Is.Zero);
                Assert.That(result, Is.InstanceOf<CustomerResponse>());
            });
        }

        [Test]
        public void MapToCustomerResponse_CustomerQueryResultParameter_ShouldGenerateCustomerResponse()
        {
            //Arrange
            var customer = MockData.CustomerQueryResult;

            //Act
            var result = CustomerGrpcMapper.MapToCustomerResponse(customer);

            //Assert
            Assert.Multiple(() =>
            {
                var units = decimal.ToInt64(customer.CashBalanceDecimal);
                var nanos = decimal.ToInt32((customer.CashBalanceDecimal - units) * NanoFactor);

                Assert.That(result.Id, Is.EqualTo(customer.Id));
                Assert.That(result.Name, Is.EqualTo(customer.Name));
                Assert.That(result.Age, Is.EqualTo(customer.Age));
                Assert.That(result.Active, Is.EqualTo(customer.Active));
                Assert.That(result.CashBalanceFloat, Is.EqualTo(customer.CashBalanceFloat));
                Assert.That(result.CashBalanceDouble, Is.EqualTo(customer.CashBalanceDouble));
                Assert.That(result.CashBalanceDecimal.Units, Is.EqualTo(units));
                Assert.That(result.CashBalanceDecimal.Nanos, Is.EqualTo(nanos));
                Assert.That(result, Is.InstanceOf<CustomerResponse>());
            });
        }

        [Test]
        public void MapToCustomerListResponse_NullParameter_ShouldGenerateEmptyCustomerListResponse()
        {
            //Act
            var result = CustomerGrpcMapper.MapToCustomerListResponse(null);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Customers, Is.Empty);
                Assert.That(result, Is.InstanceOf<CustomerListResponse>());
            });
        }

        [Test]
        public void MapToCustomerListResponse_NewListParameter_ShouldGenerateEmptyCustomerListResponse()
        {
            //Act
            var result = CustomerGrpcMapper.MapToCustomerListResponse(new List<CustomerQueryResult>());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Customers, Is.Empty);
                Assert.That(result, Is.InstanceOf<CustomerListResponse>());
            });
        }

        [Test]
        public void MapToCustomerListResponse_ListOfCustomerQueryResultParameter_ShouldGenerateCustomerListResponse()
        {
            //Arrange
            var customers = MockData.ListCustomerQueryResult;

            //Act
            var result = CustomerGrpcMapper.MapToCustomerListResponse(customers);

            //Assert
            Assert.Multiple(() =>
            {
                var units = decimal.ToInt64(customers[0].CashBalanceDecimal);
                var nanos = decimal.ToInt32((customers[0].CashBalanceDecimal - units) * NanoFactor);

                Assert.That(result.Customers[0].Id, Is.EqualTo(customers[0].Id));
                Assert.That(result.Customers[0].Name, Is.EqualTo(customers[0].Name));
                Assert.That(result.Customers[0].Age, Is.EqualTo(customers[0].Age));
                Assert.That(result.Customers[0].Active, Is.EqualTo(customers[0].Active));
                Assert.That(result.Customers[0].CashBalanceFloat, Is.EqualTo(customers[0].CashBalanceFloat));
                Assert.That(result.Customers[0].CashBalanceDouble, Is.EqualTo(customers[0].CashBalanceDouble));
                Assert.That(result.Customers[0].CashBalanceDecimal.Units, Is.EqualTo(units));
                Assert.That(result.Customers[0].CashBalanceDecimal.Nanos, Is.EqualTo(nanos));

                units = decimal.ToInt64(customers[1].CashBalanceDecimal);
                nanos = decimal.ToInt32((customers[1].CashBalanceDecimal - units) * NanoFactor);

                Assert.That(result.Customers[1].Id, Is.EqualTo(customers[1].Id));
                Assert.That(result.Customers[1].Name, Is.EqualTo(customers[1].Name));
                Assert.That(result.Customers[1].Age, Is.EqualTo(customers[1].Age));
                Assert.That(result.Customers[1].Active, Is.EqualTo(customers[1].Active));
                Assert.That(result.Customers[1].CashBalanceFloat, Is.EqualTo(customers[1].CashBalanceFloat));
                Assert.That(result.Customers[1].CashBalanceDouble, Is.EqualTo(customers[1].CashBalanceDouble));
                Assert.That(result.Customers[1].CashBalanceDecimal.Units, Is.EqualTo(units));
                Assert.That(result.Customers[1].CashBalanceDecimal.Nanos, Is.EqualTo(nanos));

                units = decimal.ToInt64(customers[2].CashBalanceDecimal);
                nanos = decimal.ToInt32((customers[2].CashBalanceDecimal - units) * NanoFactor);

                Assert.That(result.Customers[2].Id, Is.EqualTo(customers[2].Id));
                Assert.That(result.Customers[2].Name, Is.EqualTo(customers[2].Name));
                Assert.That(result.Customers[2].Age, Is.EqualTo(customers[2].Age));
                Assert.That(result.Customers[2].Active, Is.EqualTo(customers[2].Active));
                Assert.That(result.Customers[2].CashBalanceFloat, Is.EqualTo(customers[2].CashBalanceFloat));
                Assert.That(result.Customers[2].CashBalanceDouble, Is.EqualTo(customers[2].CashBalanceDouble));
                Assert.That(result.Customers[2].CashBalanceDecimal.Units, Is.EqualTo(units));
                Assert.That(result.Customers[2].CashBalanceDecimal.Nanos, Is.EqualTo(nanos));

                Assert.That(result, Is.InstanceOf<CustomerListResponse>());
            });
        }
    }
}