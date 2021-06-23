using API.Base;
using API.Models;
using API.Repository;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository account;
        public AccountsController(AccountRepository repository) : base(repository)
        {
            this.account = repository;
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginVM login)
        {
            try
            {
                var isCheck = repository.Login(login);
                switch (isCheck)
                {
                    case 1:
                        return Ok(new { status = HttpStatusCode.OK, result = isCheck, message = "Login Sukses" });
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
