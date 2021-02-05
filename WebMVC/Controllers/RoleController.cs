using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CodingCamp44.ViewModels;

namespace WebMVC.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class RoleController : Controller
    {

        public async Task<IActionResult> Index()
        {
            List<RoleVM> roles = new List<RoleVM>();            
            using (var httpClient = new HttpClient())
            {                
                using (var response = await httpClient.GetAsync("https://localhost:44383/api/Role"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    
                    string json = @"[ { 'Id': 1, 'Name': 'Customer'}, { 'Id': 2, 'Name':'Admin'} ]";
                    roles = JsonConvert.DeserializeObject<List<RoleVM>>(json);
                    TempData["data"] = roles;
                    //return Ok(new { dataDummy = roles, dataReal = apiResponse }) ;
                }
            }
            return View(roles);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RoleVM roleVM)
        {
            RoleVM _roleVM = new RoleVM();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(roleVM), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44383/api/Role", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _roleVM = JsonConvert.DeserializeObject<RoleVM>(apiResponse);
                    return Ok(new { data = apiResponse });
                }
            }
            //return View(receivedReservation);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleVM roleVM)
        {
            RoleVM _roleVM = new RoleVM();
            using (var httpClient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(roleVM), Encoding.UTF8, "application/json");

                /*var content = new MultipartFormDataContent();
                content.Add(new StringContent(roleVM.Id.ToString()), "Id");
                content.Add(new StringContent(roleVM.Name), "Name");*/

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



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44383/api/Role/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return Ok(new { data = apiResponse });
                }
            }
            //return RedirectToAction("Index");
        }
    }
}
