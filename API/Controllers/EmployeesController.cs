using API.Base;
using API.Context;
using API.Models;
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
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        public new EmployeeRepository repository;

        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPost("/API/Employees/Register")]
        public ActionResult Register(RegisterVM register)
        {
            try
            {
                var regis = repository.Register(register);
                switch(regis)
                {
                    case 4:
                        return Ok(new { status = HttpStatusCode.OK, result = regis, message = "Registrasi berhasil dilakukan" });
                    case 2:
                        return BadRequest(new { status = HttpStatusCode.BadRequest, result = regis, message = "Registrasi gagal Nik sudah ada" });
                    case 3:
                        return BadRequest(new { status = HttpStatusCode.BadRequest, result = regis, message = "Registrasi gagal Email sudah di gunakan" });
                    default:
                        return BadRequest(new { status = HttpStatusCode.BadRequest, result = regis, message = "Registrasi gagal" });
                }
            }catch (Exception)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = 0, message = "Registrasi gagal Exception di terima" });
            }
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            try
            {
                var isCheck = repository.Login(loginVM);
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
            }catch (Exception)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = 0, message = "Login gagal Exception di terima" });
            }
        }


    }
}
