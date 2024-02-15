namespace Clinic.Controllers
{
    using Appointment.Model;

    using global::Clinic.Data;
    using global::Clinic.Data.dto;
    using global::Clinic.Mapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Clinic.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class PatientController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public PatientController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/Patients
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
            {
                return await _context.Patients.ToListAsync();
            }

            // GET: api/Patients/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Patient>> GetPatient(int id)
            {
                var patient = await _context.Patients.FindAsync(id);

                if (patient == null)
                {
                    return NotFound();
                }

                return patient;
            }

            // POST: api/Patients
            [HttpPost]
            public async Task<ActionResult<Patient>> PostPatient(Patient patient)
            {
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
            }

            // PUT: api/Patients/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutPatient([FromRoute]int id, Patient patient)
            {
                Patient p = await _context.Patients.FindAsync(id); 
                if (patient == null)
                {
                    return BadRequest();
                }
                
                p.Name=patient.Name;
                p.Phone=patient.Phone;
                p.Email=patient.Email;
               

                   await _context.SaveChangesAsync();
                
              


                
                return Ok("Updted Sucessfully");
            }

        }
    }
}
