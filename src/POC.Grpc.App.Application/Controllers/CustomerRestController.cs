using Microsoft.AspNetCore.Mvc;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Rest;
using System.Threading.Tasks;

namespace POC.Grpc.App.Application.Controllers
{
    public class CustomerRestController : Controller
    {
        private readonly ICustomerRestService _customerRestService;

        public CustomerRestController(ICustomerRestService customerRestService) => _customerRestService = customerRestService;

        public async Task<IActionResult> Index()
        {
            var customers = await _customerRestService.ListAsync();
            return View(customers);
        }

        public async Task<IActionResult> Details(long id)
        {
            var customer = await _customerRestService.GetAsync(id);
            return View(customer);
        }
    }
}