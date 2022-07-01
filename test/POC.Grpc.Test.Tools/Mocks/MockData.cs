using POC.Grpc.Api.Domain.Customers.Queries.Result;
using POC.Grpc.App.Domain.Customers.Models;
using POC.Grpc.Lib.Contract.Proto.Customers.MessagesResponse;
using POC.Grpc.Test.Tools.Mocks.Customers.Grpc.Response;
using POC.Grpc.Test.Tools.Mocks.Customers.Queries.Result;
using POC.Grpc.Test.Tools.Mocks.Customers.ViewModels;
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
            CustomerQueryResult = CustomerQueryResultMock.GetCustomerQueryResult();
            ListCustomerQueryResult = CustomerQueryResultMock.GetListCustomerQueryResult();
            CustomerViewModel = CustomerViewModelMock.GetCustomerViewModel();
            ListCustomerViewModel = CustomerViewModelMock.GetListCustomerViewModel();
            CustomerResponse = CustomerResponseMock.GetCustomerResponse();
            CustomerListResponse = CustomerResponseMock.GetListCustomerResponse();
        }
    }
}