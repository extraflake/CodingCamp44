using CodingCamp44.Base.Controller;
using CodingCamp44.Models;
using CodingCamp44.Repositories.Data;
using CodingCamp44.Repositories.Interfaces;
using CodingCamp44.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingCamp44.Handler;

namespace CodingCamp44.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingController : BaseController<Profiling, ProfilingRepository, string>
    {
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        private readonly ProfilingRepository profilingRepository;

        public ProfilingController(IJWTAuthenticationManager jwtAuthenticationManager, ProfilingRepository profilingRepository) : base(profilingRepository) 
        {
           this.profilingRepository = profilingRepository;
           this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        /*[HttpGet("getByNIK/{NIK}")]
        public ActionResult getByNIK(string NIK)
        {
            var result = profilingRepository.getByNIK(NIK);
            return Ok(new { result = result, status = "Ok" });
        }*/

      /*  [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jwtAuthenticationManager.Generate(userCred.Username, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }*/
    }
}

