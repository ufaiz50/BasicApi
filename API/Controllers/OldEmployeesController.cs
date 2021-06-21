using API.Models;
using API.Repository;
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
    public class OldEmployeesController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;

        public OldEmployeesController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // Ditambahkan Exception jika ada keadaan tak terduga sehingga apps tidak berhenti di tengah jalan
        // Berdasarakan EmployeeRepository dimana jika kembaliannya null
        // Maka data tidak bisa di dapat atau belum ada record data dalam database
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var get = employeeRepository.Get();
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
                return StatusCode(500, e.Message);
            }
        }

        // Ditambahkan Exception Handling jika ada keadaan tak terduga sehingga aplikasi tidak berhenti di tengah jalan
        // Berdasarkan Method GetNIK di EmployeeRepository jika kembaliannya null maka data yang di cari tidak ada
        [HttpGet("{nik}")]
        public ActionResult Get(string nik)
        {
            try
            {
                var get = employeeRepository.GetNIK(nik);
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
                return StatusCode(500, e.Message);
            }

        }

        // Ditambahkan Exception Handling agar jika ada keadaan tak terduga sehingga aplikasi tidak berhenti ditengah jalan
        // Berdasarkan dari Method Insert di EmployeeRepository jika pengembalian 0 maka data tidak bisa di tambahkan
        [HttpPost]
        public ActionResult Insert(Employee employee)
        {
            try
            {
                var insert = employeeRepository.Insert(employee);
                if (insert == 0) return Conflict(new { 
                    status = HttpStatusCode.Conflict,
                    result = 0,
                    message = $"Data Dengan NIk : {employee.NIK} sudah ada"
                });

                return Ok(new { status = HttpStatusCode.OK, result = insert, message = "Data Berhasil Ditambahkan" });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            

            
        }

        // Ditambahkan Exception Handling agar jika ada keadaan tak terduga sehingga aplikasi tidak berhentin ditengah jalan
        // Berdasarkan Method Delete di EmployeeRepository jika pengembaliannya 0
        // Maka data yang ingin di hapus tidak ada
        [HttpDelete]
        public ActionResult Delete(string nik)
        {
            try
            {
                var delete = employeeRepository.Delete(nik);
                if (delete == 1) return Ok(new { status = HttpStatusCode.OK, result = delete, message = "Data Berhasil Dihapus" });

                return BadRequest(new
                {
                    status = HttpStatusCode.NotFound,
                    result = delete,
                    message = $"Data dengan NIK : {nik} tidak ada"
                });
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // Di Controller ada Exception untuk menangani keaadan tak terduka dan agar aplikasi di berhenti di tengah jalan
        // Sesuai yang ada di repo, bahwa dilakukan pemeriksaan data, jika data tidak ada maka dati tidak bisa di update
        // tetapi jika data ada maka bisa di update
        [HttpPut]
        public ActionResult Update(Employee employee, string nik)
        {
            try
            {
                var update = employeeRepository.Update(employee, nik);
                if (update == 0)
                    return NotFound(new
                    {
                        status = HttpStatusCode.NotFound,
                        result = 0,
                        message = $"Data dengan NIK : {nik} tidak ada"
                    });
                return Ok(new
                {
                    status = HttpStatusCode.OK,
                    result = update,
                    message = "Data Berhasil di Update"
                });

            }catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
