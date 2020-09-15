using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Models;
using ClinicManagement;
using ClinicManagement.Repositary;

namespace Clinic_Management.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        //private readonly ClinicContext _context;
        IPatientRep db;
        public PatientsController(IPatientRep _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(PatientsController));
        }

        // GET: api/Patients
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("SalaryDetailController GET ALL Action Method called");
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

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var obj = db.GetDetail(id);
                if (obj == null)
                    return NotFound();
                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Patient obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.UpdateDetail(id, obj);
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

        // POST: api/Patients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post([FromBody] Patient obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.AddDetail(obj);
                    if (result != 0)
                        return Ok(result);

                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = db.Delete(id);
                if (result != 0)
                    return Ok(result);
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //private bool PatientExists(int id)
        //{
        //return _context.Patients.Any(e => e.PatientId == id);
        //}
    }
}