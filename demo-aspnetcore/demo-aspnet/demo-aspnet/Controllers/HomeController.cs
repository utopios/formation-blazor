using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using demo_aspnet.DTOs;
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
        //Pour envoyer des données à la vue razor
        ViewBag.Firstname = "Ihab";

        ViewData["firstname"] = "ihab";

        Person person = new Person()
        {
            Firstname = "Ihab",
            Lastname = "Abadi"
        };
        
        //Un objet dynamic
        // dynamic objetDynamic = new object();
        // objetDynamic.Firstname = "Ihab";
        
        return View(person);
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