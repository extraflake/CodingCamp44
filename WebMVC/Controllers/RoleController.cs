using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CodingCamp44.ViewModels;
using CodingCamp44.Models;

namespace WebMVC.Controllers
{
    public class RoleController : Controller
    {
        public async Task<ActionResult> Index()
        
        {
            List<RoleVM> roleList = new List<RoleVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44383/api/Role"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    roleList = JsonConvert.DeserializeObject<List<RoleVM>>(apiResponse);
                }
            }
            return View(roleList);
        }
    }
}
