using CodingCamp44.Base.Controller;
using CodingCamp44.Models;
using CodingCamp44.Repositories.Data;
using CodingCamp44.Repositories.Interfaces;
using CodingCamp44.ViewModels;
using CodingCamp44.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingController : BaseController<Profiling, ProfilingRepository>
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly ProfilingRepository profilingRepository;

        public ProfilingController(IJwtAuthenticationManager jwtAuthenticationManager, ProfilingRepository profilingRepository) : base(profilingRepository) 
        {
           this.profilingRepository = profilingRepository;
           this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet("getByNIK/{NIK}")]
        public ActionResult getByNIK(string NIK)
        {
            var result = profilingRepository.getByNIK(NIK);
            return Ok(new { result = result, status = "Ok" });
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}

