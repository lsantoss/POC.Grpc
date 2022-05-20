using Microsoft.AspNetCore.Mvc;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Rest;
using System.Threading.Tasks;

namespace POC.Grpc.App.Application.Controllers
{
    public class CustomerRestController : Controller
    {
        private readonly ICustomerRestService _customerRestService;

        public CustomerRestController(ICustomerRestService customerRestService) => _customerRestService = customerRestService;

        public async Task<ActionResult> Index()
        {
            var customers = await _customerRestService.List();
            return View(customers);
        }

        public async Task<ActionResult> Details(long id)
        {
            var customer = await _customerRestService.Get(id);
            return View(customer);
        }
    }
}