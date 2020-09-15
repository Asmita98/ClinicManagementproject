using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Models;
using ClinicManagement.Repositary;

namespace Clinic_Management.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        IDoctorRep db;
        //private readonly ClinicContext _context;
        public DoctorsController(IDoctorRep _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(DoctorsController));

        }
        // GET: api/<DOCTORSCONTROLLER>
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("EmployeeController GET ALL Action Method called");
            try
            {
                var obj = db.GetDetails();
                if (obj == null)
                    return NotFound();
                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<DOCTORSCONTROLLER>/5
        [HttpGet("{id}")]
        public IActionResult Get1(int id)
        {
            Doctor data = new Doctor();
            try
            {
                data = db.GetDetail(id);
                if (data == null)
                {
                    return BadRequest(data);
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest(data);
            }
        }

        // POST api/<DOCTORSCONTROLLER>
        [HttpPost]
        public string Post([FromBody] Doctor obj)
        {
           
            return db.AddDetail(obj);
        }

        // PUT api/<DOCTORSCONTROLLER>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Doctor doc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.UpdateDetail(id, doc);
                    if (result != 1)
                        return NotFound();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                    "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // DELETE api/<DOCTORSCONTROLLER>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = db.Delete(id);
                if (result == 0)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(id);
            }
        }
    }

}