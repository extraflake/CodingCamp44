using CodingCamp44.Base.Controller;
using CodingCamp44.Context;
using CodingCamp44.Models;
using CodingCamp44.Repositories.Data;
using CodingCamp44.Repositories;
using CodingCamp44.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CodingCamp44.Handler;

namespace CodingCamp44.Controllers
{
    ///[Authorize]
    [Route("api/[controller]")]
    [ApiController]    

    public class AccountController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        private readonly PersonRepository personRepository;
        
        private IConfiguration Configuration;
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public AccountController(AccountRepository accountRepository, PersonRepository personRepository, IConfiguration Configuration, IJWTAuthenticationManager jWTAuthenticationManager) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.personRepository = personRepository;
            this.Configuration = Configuration;
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }

        [HttpPut("ChangePassword/{NIK}")]
        public ActionResult ChangePassword(string NIK, ChangePasswordVM changePasswordVM) 
        {
            var acc = accountRepository.Get(NIK);
            if (acc != null)
            {
                if (acc.Password == changePasswordVM.OldPassword)
                {
                    var data = accountRepository.ChangePassword(NIK, changePasswordVM.NewPassword);
                    return Ok(data);
                }
                else 
                {
                    return StatusCode(404, new { status = "404", message = "Wrong password" });
                }
            }
            return NotFound();
        }/*

         [HttpGet("getByNIK/{NIK}")]
        public ActionResult getByNIK(string NIK) 
        {
            var result = accountRepository.getByNIK(NIK);
            return Ok(new { result = result, status = "Ok" });
        }*/

        [HttpPut("reset/{email}/{id}")]
        public ActionResult ResetPassword(Account account, string email)
        {
            var data = accountRepository.ResetPassword(account, email);
            return (data > 0) ? (ActionResult)Ok(new { message = "Email has been Sent, password changed", status = "Ok" }) : NotFound(new { message = "Data not exist in our database, please register first", status = 404 });
        }/*

        [HttpGet("get/{id}")]
        public ActionResult GetAccountById(string id)
        {
            var data = accountRepository.GetAccountById(id);
            return (data != null) ? (ActionResult)Ok(new { data, status = "Ok" }) : NotFound(new { data, status = "Not Found" });
        }
*//*
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteAccount(string id)
        {
            if (accountRepository.GetAccountById(id) == null)
            {
                return NotFound();
            }
            var data = accountRepository.DeleteAccount(id);
            return Ok(data);
        }*/

      /*  [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jWTAuthenticationManager.Generate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }*/
        /*private string GenerateJSONWebToken(LoginVM userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var dataPerson = personRepository.GetDataByEmail(userInfo.Email);

            var claims = new[] {
                new Claim("Email", dataPerson.Email),
                new Claim("FirstName", dataPerson.FirstName),
                new Claim("LastName", dataPerson.LastName)
            };

            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                Configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
*/
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var data = accountRepository.Register(registerVM);
                if (data > 0)
                {
                    return Ok(new { status = "Registration Successed..." });
                }
                else
                {
                    return StatusCode(500, new { status = "Internal server error..." });
                }
            }
            else {
                return BadRequest(new { status = "Bad request...", errorMessage = "Data input is not valid..."});
            }
        }
    }
}

