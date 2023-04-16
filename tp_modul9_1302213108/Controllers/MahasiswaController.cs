using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tp_modul9_1302213108.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<mahasiswa> data = new List<mahasiswa>
        {
            new mahasiswa("Yesa Krisanto Sihombing","1302213108"),
            new mahasiswa("Tangguh Laksana","1302210025"),
            new mahasiswa("Fathur Rahman Kosasih","1302210063"),
            new mahasiswa("Ghaza Gymnastiar Solihin","1302210093")
        };
        // GET: api/<MahasiswaController>
        [HttpGet]
        public IEnumerable<mahasiswa> Get()
        {
            return data;
        }

        // GET api/<MahasiswaController>/5
        [HttpGet("{id}")]
        public ActionResult<mahasiswa> Get(int id)
        {
            try
            {
                if (data == null || id < 0 || id >= data.Count)
                {
                    return NotFound("data mahasiswa tidak ditemukan");
                }
                return data[id];
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MahasiswaController>
        [HttpPost]
        public void Post([FromBody] mahasiswa value)
        {
            if (value == null)
            {
                BadRequest("Data mahasiswa tidak valid");
                return;
            }
            data.Add(value);
            CreatedAtAction(nameof(Get), new { id = data.IndexOf(value) }, value);
        }

        // PUT api/<MahasiswaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] mahasiswa value)
        {
            try
            {
                if (data == null || id < 0 || id >= data.Count || value == null)
                {
                    NotFound("Data mahasiswa tidak valid dan tidak ditemukan sama sekali"); // Return a NotFound response if data is null, or id is out of range, or value is null
                    return;
                }

                data[id].nama = value.nama;
                data[id].nim = value.nim;

                NoContent();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message); // Return a BadRequest response if an exception occurs
            }
        }

        // DELETE api/<mahasiswaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                if (data == null || id < 0 || id >= data.Count)
                {
                    NotFound("Data mahasiswa tidak ditemukan"); // Return a NotFound response if data is null, or id is out of range
                    return;
                }

                data.RemoveAt(id);
                NoContent();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
    }
}
