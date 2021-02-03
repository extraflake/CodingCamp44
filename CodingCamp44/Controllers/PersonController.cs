using CodingCamp44.Base.Controller;
using CodingCamp44.Handler;
using CodingCamp44.Models;
using CodingCamp44.Repositories.Data;
using CodingCamp44.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PersonController : BaseController<Person, PersonRepository, string>
    {
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        private readonly PersonRepository personRepository;

        public PersonController(IJWTAuthenticationManager jwtAuthenticationManager, PersonRepository personRepository) : base(personRepository) 
        {
            this.personRepository = personRepository;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

       /* [HttpGet("get/{id}")]
        public ActionResult GetPersonById(string id)
        {
            var data = personRepository.GetPersonById(id);
            return (data != null) ? (ActionResult)Ok(new { data, status = "Ok" }) : NotFound(new { data, status = "Not Found" });
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeletePerson(string id)
        {
            if (personRepository.GetPersonById(id) == null)
            {
                return NotFound();
            }
            var data = personRepository.DeletePerson(id);
            return Ok(data);
	}

        [HttpGet("getByNIK/{NIK}")]
        public ActionResult getByNIK(string NIK) 
        {
            var result = personRepository.getByNIK(NIK);
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

