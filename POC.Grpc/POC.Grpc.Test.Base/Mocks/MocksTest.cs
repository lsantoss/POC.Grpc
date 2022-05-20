using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.App.Domain.Customers.Models;
using POC.Grpc.Lib.Proto.Messages.Response;
using POC.Grpc.Test.Base.Mocks.Customers;
using System.Collections.Generic;

namespace POC.Grpc.Test.Base.Mocks
{
    public class MocksTest
    {
        public CustomerQueryResult CustomerQueryResult { get; }
        public List<CustomerQueryResult> ListCustomerQueryResult { get; }
        public CustomerViewModel CustomerViewModel { get; }
        public List<CustomerViewModel> ListCustomerViewModel { get; }
        public CustomerResponse CustomerResponse { get; }
        public CustomerListResponse CustomerListResponse { get; }

        public MocksTest()
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