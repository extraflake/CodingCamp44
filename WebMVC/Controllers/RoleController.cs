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
    [Route("[controller]")]
    public class RoleController : Controller
    {
        //public async Task<ActionResult> Index()
        
        //{
        //    List<RoleVM> roleList = new List<RoleVM>();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44383/api/Role"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            roleList = JsonConvert.DeserializeObject<List<RoleVM>>(apiResponse);
        //        }
        //    }
        //    return Json(roleList);
        //}

        //public async Task<IActionResult> UpdateRole(int id)
        //{
        //    RoleVM roleVM = new RoleVM();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44383/api/Role" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            roleVM = JsonConvert.DeserializeObject<RoleVM>(apiResponse);
        //        }
        //    }
        //    return View(roleVM);
        //}

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleVM roleVM)
        {
            RoleVM receivedRole = new RoleVM();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(roleVM.Id.ToString()), "Id");
                content.Add(new StringContent(roleVM.Name), "Name");

                using (var response = await httpClient.PutAsync("https://localhost:44383/api/Role", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedRole = JsonConvert.DeserializeObject<RoleVM>(apiResponse);
                }
            }
            return Json(receivedRole);
        }
    }
}
