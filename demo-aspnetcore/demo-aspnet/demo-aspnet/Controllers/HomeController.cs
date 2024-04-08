using System.Diagnostics;
using demo_aspnet.Interfaces;
using Microsoft.AspNetCore.Mvc;
using demo_aspnet.Models;
using demo_aspnet.Services;

namespace demo_aspnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IUpload _uploadService;
    public HomeController(ILogger<HomeController> logger, IUpload uploadService)
    {
        _logger = logger;
        _uploadService = uploadService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}