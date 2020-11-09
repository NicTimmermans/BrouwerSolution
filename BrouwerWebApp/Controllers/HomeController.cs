using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BrouwerWebApp.Models;
using BrouwerService.Repositories;

namespace BrouwerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrouwerRepository repository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBrouwerRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }


        public async Task<IActionResult> Index() => View(await repository.FindAllAsync());


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
}
