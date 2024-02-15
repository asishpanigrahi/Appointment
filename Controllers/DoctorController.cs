using Appointment.Model;
using Clinic.Data;
using Clinic.Data.dto;
using Clinic.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{

    [Route("/api/[Controller]")]
    [ApiController()]
    public class DoctorController:Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            // Retrieve doctors from the context
            var doctors = await _context.Doctors.ToListAsync();

            // Map Doctor entities to DoctorDto using DoctorMapper
            var doctorDtos = doctors.Select(doctor => DoctorMapper.Fromdoctor(doctor)).ToList();

            return Ok(doctorDtos);
        }


        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
        {
            // Retrieve doctor from the context
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            // Map Doctor entity to DoctorDto using DoctorMapper
            var doctorDto = DoctorMapper.Fromdoctor(doctor);

            return Ok(doctorDto);
        }


        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<DoctorDto>> PostDoctor([FromBody]DoctorDto doctorDto)
        {
            // Convert DoctorDto to Doctor entity
            Doctor doctor = DoctorMapper.Todoctor(doctorDto); // Use the mapper method

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            // Convert the created Doctor entity back to DoctorDto
            //DoctorDto createdDoctorDto = DoctorMapper.Fromdoctor(doctor);

            return Ok("Sucess");

        }

            // PUT: api/Doctors/5
            [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, DoctorDto doctorDto)
        {
            Doctor doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return BadRequest();
            }

            doctor.Name = doctorDto.Name;   
            doctor.Specialization = doctorDto.Specialization;

            await _context.SaveChangesAsync();

           
            

            return Ok("Sucessfully Updated");
        }



        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return Ok("Deleted the record");
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
