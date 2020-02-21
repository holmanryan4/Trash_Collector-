using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext options)
        {
            _context = options;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var user = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCustomer = _context.Customer.Where(s => s.AppUserId == user).FirstOrDefault();
            var employeeUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userEmployee = _context.Customer.Where(s => s.AppUserId == user).FirstOrDefault();

            if (userCustomer == null)
            {
                return RedirectToAction("Account", "Customers");
            }
            else if (userCustomer != null)
            {
                return RedirectToAction("CustomerHomepage", "Customers");
            }
            if (userEmployee == null)
            {
                return RedirectToAction("Create", "Employees");
            }
            else if(userEmployee != null)
            {
                return RedirectToAction("index", "Customers");
            }
           
            
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
}
