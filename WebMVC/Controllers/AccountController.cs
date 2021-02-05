using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
