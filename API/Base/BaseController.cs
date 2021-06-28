using API.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Base
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        public Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var get = repository.Get();
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

        
        [HttpGet("{key}")]
        public ActionResult Get(Key key)
        {
            try
            {
                var get = repository.GetNIK(key);
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

        
        [HttpDelete]
        public ActionResult Delete(Key key)
        {
            try
            {
                var delete = repository.Delete(key);
                if (delete == 1) return Ok(new { status = HttpStatusCode.OK, result = delete, message = "Data Berhasil Dihapus" });

                return BadRequest(new
                {
                    status = HttpStatusCode.NotFound,
                    result = delete,
                    message = $"Data dengan NIK : {key} tidak ada"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = HttpStatusCode.InternalServerError, result = e.Message, message = "terjadi exception" });
            }
        }

        
        [HttpPost]
        public ActionResult Insert(Entity entity)
        {
            try
            {
                var insert = repository.Insert(entity);
                if (insert == 0) return Conflict(new
                {
                    status = HttpStatusCode.Conflict,
                    result = 0,
                    message = $"Data Dengan NIk : {entity} sudah ada"
                });

                return Ok(new { status = HttpStatusCode.OK, result = insert, message = "Data Berhasil Ditambahkan" });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = HttpStatusCode.InternalServerError, result = e.Message, message = "terjadi exception" });
            }



        }

        
        [HttpPut]
        public ActionResult Update(Entity entity, Key key)
        {
            try
            {
                var update = repository.Update(entity, key);
                if (update == 0)
                    return NotFound(new
                    {
                        status = HttpStatusCode.NotFound,
                        result = 0,
                        message = $"Data dengan NIK : {key} tidak ada"
                    });
                return Ok(new
                {
                    status = HttpStatusCode.OK,
                    result = update,
                    message = "Data Berhasil di Update"
                });

            }
            catch (Exception e)
            {
                return BadRequest(new { status = HttpStatusCode.InternalServerError, result = e.Message, message = "terjadi exception" });
            }
        }
    }
}
