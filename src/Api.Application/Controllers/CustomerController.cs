using Microsoft.AspNetCore.Mvc;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using System.Threading.Tasks;

namespace POC.Grpc.Api.Application.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository) => _repository = repository;

        [HttpGet]
        [Route("v1/customers")]
        public async Task<IActionResult> ListAsync()
        {
            var customers = await _repository.ListAsync();
            return customers != null ? StatusCode(200, customers) : StatusCode(204);
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var customer = await _repository.GetAsync(id);
            return customer != null ? StatusCode(200, customer) : StatusCode(204);
        }
    }
}