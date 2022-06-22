using Microsoft.AspNetCore.Mvc;
using POC.Grpc.App.Application.Models;
using System.Diagnostics;

namespace POC.Grpc.App.Application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}