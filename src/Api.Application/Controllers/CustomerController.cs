using Microsoft.AspNetCore.Mvc;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;

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
        public IActionResult List()
        {
            var customers = _repository.List();

            return customers != null 
                ? StatusCode(200, customers) 
                : StatusCode(204);
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public IActionResult Get(long id)
        {
            var customer = _repository.Get(id);

            return customer != null
                ? StatusCode(200, customer)
                : StatusCode(204);
        }
    }
}