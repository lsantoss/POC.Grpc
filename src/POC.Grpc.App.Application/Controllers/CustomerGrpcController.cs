using Microsoft.AspNetCore.Mvc;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Grpc;
using System.Threading.Tasks;

namespace POC.Grpc.App.Application.Controllers
{
    public class CustomerGrpcController : Controller
    {
        private readonly ICustomerGrpcService _customerGrpcService;

        public CustomerGrpcController(ICustomerGrpcService customerGrpcService) => _customerGrpcService = customerGrpcService;

        public async Task<IActionResult> Index()
        {
            var customers = await _customerGrpcService.ListAsync();
            return View(customers);
        }

        public async Task<IActionResult> Details(long id)
        {
            var customer = await _customerGrpcService.GetAsync(id);
            return View(customer);
        }
    }
}
