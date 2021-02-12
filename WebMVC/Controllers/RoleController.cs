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
using System.Net;

namespace WebMVC.Controllers
{
    public class RoleController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public HttpStatusCode Create(RoleVM roleVM)
        {
            var httpClient = new HttpClient();
            
            StringContent content = new StringContent(JsonConvert.SerializeObject(roleVM), Encoding.UTF8, "application/json");

            var result = httpClient.PostAsync("https://localhost:44383/api/Role/", content).Result;
            return result.StatusCode;
            
        }

        [HttpDelete]
        public HttpStatusCode Delete(int Id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.DeleteAsync("https://localhost:44383/api/Role/" + Id).Result;
            return response.StatusCode;
        }

        [HttpGet]
        public String Get(int Id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:44383/api/Role/" + Id).Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            return apiResponse.Result;
        }

        [HttpPut]
        public HttpStatusCode Update(RoleVM roleVM)
        {
            var httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(roleVM), Encoding.UTF8, "application/json");

            var result = httpClient.PutAsync("https://localhost:44383/api/Role/", content).Result;
            return result.StatusCode;
        }
    }
}
