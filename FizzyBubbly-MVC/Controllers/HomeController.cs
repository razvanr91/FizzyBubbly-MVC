using FizzyBubbly_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FizzyBubbly_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Fizzy()
        {
            FizzBuzz model = new();

            model.FizzValue = 3;
            model.BuzzValue = 5;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Fizzy(FizzBuzz fizzBuzz)
        {
            bool fizz;
            bool buzz;


            for ( var i = 1; i <= 100; i++ )
            {
                fizz = i % fizzBuzz.FizzValue == 0;
                buzz = i % fizzBuzz.BuzzValue == 0;

                if ( fizz && buzz )
                {
                    fizzBuzz.Results.Add("FizzBuzz");
                }
                else if ( fizz )
                {
                    fizzBuzz.Results.Add("Fizz");
                }
                else if ( buzz )
                {
                    fizzBuzz.Results.Add("Buzz");
                }
                else
                {
                    fizzBuzz.Results.Add(i.ToString());
                }
            }


            return View(fizzBuzz);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
