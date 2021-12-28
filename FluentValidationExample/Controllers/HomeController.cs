using FluentValidation.Results;
using FluentValidationExample.Models;
using FluentValidationExample.Models.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationExample.Controllers
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
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            LoginValidator validator = new LoginValidator();
            ValidationResult result = validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
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
