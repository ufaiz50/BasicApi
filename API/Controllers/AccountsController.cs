using API.Base;
using API.Context;
using API.Models;
using API.Repository;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize(Roles = "Employee,Manageer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        public IConfiguration _configuration;
        private readonly MyContext myContext;

        public AccountsController(AccountRepository repository, IConfiguration configuration, MyContext myContext) : base(repository)
        {
            _configuration = configuration;
            this.myContext = myContext;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM login)
        {
            try
            {
                var isCheck = repository.Login(login);
                switch (isCheck)
                {
                    case 1:
                    var getData = repository.GetDataLogin(login);
                        var jwt = new Jwt.Jwt(_configuration, myContext).GenJwt(getData);
                        return Ok(new { status = HttpStatusCode.OK, token = jwt, message = "Login Sukses" });
                    case 2:
                        return BadRequest(new { status = HttpStatusCode.BadRequest, result = isCheck, message = "NIK/ Email tidak sesuai dengan data didatabase" });
                    case 3:
                        return BadRequest(new { status = HttpStatusCode.BadRequest, result = isCheck, message = "Password tidak sesuai dengan data didatabase" });
                    default:
                        return BadRequest(new { status = HttpStatusCode.BadRequest, result = isCheck, message = "NIK dan Password tidak sesuai dengan data didatabase" });
                }
            }
            catch (Exception)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = 0, message = "Login gagal Exception di terima" });
            }
        }



        [HttpPut("UpdatePassword")]
        public ActionResult UpdatePassword(UpdatePasswordVM updatePassword)
        {
            try
            {
                var update = repository.UpdatePassword(updatePassword);

                switch (update)
                {
                    case 1:
                        return Ok(new { status = HttpStatusCode.OK, result = update, message = "Data Tersebut Berhasil di Update" });
                    case 2:
                        return BadRequest(new { status = HttpStatusCode.BadRequest, result = update, message = "Kata sandi lama tidak sesuai database" });
                    default:
                        return NotFound(new { status = HttpStatusCode.NotFound, result = 0, message = "Data dengan NIK/Email tersebut tidak ada di Database" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = HttpStatusCode.InternalServerError, result = e.Message, message = "terjadi exception" });
            }
        }

        [HttpPut("ResetPassword")]
        public ActionResult ResetPassword(ResetPasswordVM resetPassword)
        {
            var reset = repository.ResetPassword(resetPassword);
            if (reset == 0) return BadRequest( new { status = HttpStatusCode.NotFound, result = 0, message ="Nik atau Email tidak terdaftar" });
            return Ok( new { status = HttpStatusCode.OK, result = 1, message = "Password Baru Sudah Dikirim di email" });
        }
    }
}
