using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebUI.Models;
using Microsoft.AspNetCore.Cors;

namespace WebUI.Controllers
{
    public class BindController : Controller
    {

        private readonly ILogger<BindController> _logger;

        public BindController(ILogger<BindController> logger)
        {
            _logger = logger;
        }
        public IActionResult Bind()
        {
            return View();
        }
        public IActionResult Unbind()
        {
            return View();
        }
    }
}
