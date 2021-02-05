using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CodingCamp44.ViewModels;
using CodingCamp44.Models;
using System.Text;

namespace WebMVC.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class RoleController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleVM roleVM)
        {
            RoleVM addRole = new RoleVM();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(roleVM), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44383/api/Role/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    addRole = JsonConvert.DeserializeObject<RoleVM>(apiResponse);
                }
            }
            return Ok();
        }
        [HttpDelete("{roleId}")]
        public async Task<IActionResult> Delete(int roleId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44383/api/Role/" + roleId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleVM roleVM)
        {
            RoleVM _roleVM = new RoleVM();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(roleVM), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44383/api/Role", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    _roleVM = JsonConvert.DeserializeObject<RoleVM>(apiResponse);
                    return Ok(new { data = apiResponse });
                }
            }
            //return View(receivedReservation);
        }
    }
}
