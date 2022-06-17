using POC.Grpc.App.Domain.Customers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Grpc.App.Domain.Customers.Interfaces.Services.Rest
{
    public interface ICustomerRestService
    {
        Task<CustomerViewModel> Get(long id);
        Task<List<CustomerViewModel>> List();
    }
}