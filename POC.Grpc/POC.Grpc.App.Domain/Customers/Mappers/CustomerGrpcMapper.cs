using POC.Grpc.App.Domain.Customers.Models;
using POC.Grpc.Lib.Mappers;
using POC.Grpc.Lib.Proto.Customers.MessagesResponse;
using System.Collections.Generic;

namespace POC.Grpc.App.Domain.Customers.Mappers
{
    public static class CustomerGrpcMapper
    {
        public static CustomerViewModel MapToCustomerViewModel(this CustomerResponse customerResponse)
        {
            if (customerResponse == null)
                return null;
            else if (customerResponse.CalculateSize() == 0)
                return null;
            else
                return new()
                {
                    Id = customerResponse.Id,
                    Name = customerResponse.Name,
                    Age = customerResponse.Age,
                    Active = customerResponse.Active,
                    CashBalanceFloat = customerResponse.CashBalanceFloat,
                    CashBalanceDouble = customerResponse.CashBalanceDouble,
                    CashBalanceDecimal = DecimalGrpcMapper.Map(customerResponse.CashBalanceDecimal)
                };
        }

        public static List<CustomerViewModel> MapToListOfCustomerViewModel(this CustomerListResponse customerListResponse)
        {
            var customers = new List<CustomerViewModel>();

            if (customerListResponse == null || (customerListResponse?.Customers?.Count) <= 0)
                return customers;

            foreach (var customerResponse in customerListResponse.Customers)
                customers.Add(MapToCustomerViewModel(customerResponse));

            return customers;
        }
    }
}