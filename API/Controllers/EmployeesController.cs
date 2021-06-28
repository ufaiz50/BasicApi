using API.Base;
using API.Context;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize(Roles = "Employee,Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        public new EmployeeRepository repository;

        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [AllowAnonymous]
        [HttpPost("/API/Employees/Register")]
        public ActionResult Register(RegisterVM register)
        {
            try
            {
                var regis = repository.Register(register);
                switch(regis)
                {
                    case 5:
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


        [Authorize]
        [HttpGet("ShowData")]
        public ActionResult ShowData()
        {
            try
            {
                var get = repository.ShowData();
                if (get == null)
                    return NotFound(new
                    {
                        status = HttpStatusCode.NotFound,
                        result = get,
                        message = "Data tidak berhasil didapat atau belum ada data di dalam database"
                    });
                return Ok(new { status = HttpStatusCode.OK, result = get, message = "Data berhasil didapat" });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = HttpStatusCode.InternalServerError, result = e.Message, message = "terjadi exception" });
            }
        }

        [HttpGet("ShowDataByNIK/{nik}")]
        public ActionResult ShowDataByNIK(string NIK)
        {
            try
            {
                var get = repository.ShowDataByNIK(NIK);
                if (get == null)
                    return NotFound(new
                    {
                        status = HttpStatusCode.NotFound,
                        result = get,
                        message = "Data tidak tersedia"
                    });
                return Ok(new { status = HttpStatusCode.OK, result = get, message = "Data berhasil didapat" });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = HttpStatusCode.InternalServerError, result = e.Message, message = "terjadi exception" });
            }
        }
    }
}
