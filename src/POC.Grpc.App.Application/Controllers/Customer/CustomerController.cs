using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using POC.Grpc.App.Application.Enums;
using POC.Grpc.App.Application.Models.Customer;
using static POC.Grpc.Client.Lib.Protos.Customers.Services.CustomerService;

namespace POC.Grpc.App.Application.Controllers.Customer;

public class CustomerController : Controller
{
    private readonly CustomerServiceClient _customerServiceClient;

    public CustomerController(CustomerServiceClient customerServiceClient)
    {
        _customerServiceClient = customerServiceClient;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var response = await _customerServiceClient.ListAsync(new Empty());

        var result = response.Items.Select(item => new CustomerViewModel
        {
            Id = item.Id,
            Name = item.Name,
            Birth = item.Birth.ToDateTime(),
            Active = item.Active,
            Gender = (Gender)item.Gender.GetHashCode(),
            CashBalance = item.CashBalance
        }).ToList();

        return View(result);
    }

    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var response = await _customerServiceClient.GetAsync(new() 
        { 
            Id = id 
        });

        var result = new CustomerViewModel()
        {
            Id = response.Customer.Id,
            Name = response.Customer.Name,
            Birth = response.Customer.Birth.ToDateTime(),
            Active = response.Customer.Active,
            Gender = (Gender)response.Customer.Gender.GetHashCode(),
            CashBalance = response.Customer.CashBalance
        };

        return View(result);
    }

    [HttpGet]
    public ActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CustomerViewModel formData)
    {
        var response = await _customerServiceClient.InsertAsync(new()
        {
            Name = formData.Name,
            Birth = formData.Birth.ToUniversalTime().ToTimestamp(),
            Active = formData.Active,
            Gender = (Client.Lib.Protos.Customers.Services.Gender)formData.Gender.GetHashCode(),
            CashBalance = formData.CashBalance
        });

        if (response.Success)
        {
            TempData["toastr-success"] = response.Reason;
            return RedirectToAction("Index");
        }
        else
        {
            TempData["toastr-error"] = response.Reason;
            return RedirectToAction("Create");
        }
    }

    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var response = await _customerServiceClient.GetAsync(new()
        { 
            Id = id 
        });

        var result = new CustomerViewModel()
        {
            Id = response.Customer.Id,
            Name = response.Customer.Name,
            Birth = response.Customer.Birth.ToDateTime(),
            Active = response.Customer.Active,
            Gender = (Gender)response.Customer.Gender.GetHashCode(),
            CashBalance = response.Customer.CashBalance
        };

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(CustomerViewModel formData)
    {
        var response = await _customerServiceClient.UpdateAsync(new()
        {
            Id = formData.Id,
            Name = formData.Name,
            Birth = formData.Birth.ToUniversalTime().ToTimestamp(),
            Active = formData.Active,
            Gender = (Client.Lib.Protos.Customers.Services.Gender)formData.Gender.GetHashCode(),
            CashBalance = formData.CashBalance
        });

        if (response.Success)
        {
            TempData["toastr-success"] = response.Reason;
            return RedirectToAction("Index");
        }
        else
        {
            TempData["toastr-error"] = response.Reason;
            return RedirectToAction($"Update/{formData.Id}");
        }
    }

    [HttpGet]
    public async Task<ActionResult> Delete(int id)
    {
        var response = await _customerServiceClient.GetAsync(new() 
        { 
            Id = id 
        });

        var result = new CustomerViewModel()
        {
            Id = response.Customer.Id,
            Name = response.Customer.Name,
            Birth = response.Customer.Birth.ToDateTime(),
            Active = response.Customer.Active,
            Gender = (Gender)response.Customer.Gender.GetHashCode(),
            CashBalance = response.Customer.CashBalance
        };

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(CustomerViewModel formData)
    {
        var response = await _customerServiceClient.DeleteAsync(new() 
        { 
            Id = formData.Id 
        });

        if (response.Success)
        {
            TempData["toastr-success"] = response.Reason;
            return RedirectToAction("Index");
        }
        else
        {
            TempData["toastr-error"] = response.Reason;
            return RedirectToAction($"Delete/{formData.Id}");
        }
    }
}