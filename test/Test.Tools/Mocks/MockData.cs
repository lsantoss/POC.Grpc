using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.App.Domain.Customers.Models;
using POC.Grpc.Lib.Contract.Proto.Customers.MessagesResponse;
using POC.Grpc.Test.Tools.Mocks.Customers;
using System.Collections.Generic;

namespace POC.Grpc.Test.Tools.Mocks
{
    public class MockData
    {
        public CustomerQueryResult CustomerQueryResult { get; }
        public List<CustomerQueryResult> ListCustomerQueryResult { get; }
        public CustomerViewModel CustomerViewModel { get; }
        public List<CustomerViewModel> ListCustomerViewModel { get; }
        public CustomerResponse CustomerResponse { get; }
        public CustomerListResponse CustomerListResponse { get; }

        public MockData()
        {
            CustomerQueryResult = CustomerMock.GetCustomerQueryResult();
            ListCustomerQueryResult = CustomerMock.GetListCustomerQueryResult();
            CustomerViewModel = CustomerMock.GetCustomerViewModel();
            ListCustomerViewModel = CustomerMock.GetListCustomerViewModel();
            CustomerResponse = CustomerMock.GetCustomerResponse();
            CustomerListResponse = CustomerMock.GetListCustomerResponse();
        }
    }
}