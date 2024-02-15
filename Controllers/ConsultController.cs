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
    public class ConsultController: Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consult>>> GetAppointments()
        {
            return await _context.Consults.ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultDto>> GetAppointment(int id)
        {
            var appointment = await _context.Consults.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }


            return ConsultMapper.FromConsult(appointment);
        }

        [HttpGet("GetByPatientName/{patientName}")]
        public async Task<ActionResult<IEnumerable<ConsultDto>>> GetConsultationsByPatientName(string patientName)
        {
            // Retrieve consultations for the specified patient name
            var consultations = await _context.Consults
                .Include(c => c.Patient)
                .Where(c => c.Patient.Name == patientName)
                .ToListAsync();

            // Map Consult entities to ConsultDto using ConsultMapper
            var consultDtos = consultations.Select(c => ConsultMapper.FromConsult(c)).ToList();

            return Ok(consultDtos);
        }



        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<Consult>> PostAppointment(ConsultDto consult)
        {
            Consult c = new Consult
            {
                Description = consult.Description,
                EndTime = consult.EndTime,
                status=consult.status,
                StartTime = consult.StartTime
            };

            Doctor doctor1 = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == consult.DocterID);
            Patient patient1 = await _context.Patients.FirstOrDefaultAsync(x => x.Id == consult.PatientID);
            c.Docter = doctor1;
            c.Patient = patient1;
            _context.Consults.Add(c);
            await _context.SaveChangesAsync();
         

            
            // Convert the created Doctor entity back to DoctorDto
           // DoctorDto createdDoctorDto = DoctorMapper.Fromdoctor(doctor);


            return Ok("sucess");
        }

        // PUT: api/Appointments/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Consult>> PutAppointment(ConsultDto consultDto)
        {
            // Create a new Consult object and map properties from ConsultDto

            Consult c = await _context.Consults.FindAsync(consultDto.Id);
           c.Description= consultDto.Description;
            c.StartTime= consultDto.StartTime;
            c.EndTime= consultDto.EndTime;
            c.status= consultDto.status;
            

            // Retrieve Doctor and Patient entities from the database based on IDs
            Doctor doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == consultDto.DocterID);
            Patient patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == consultDto.PatientID);

            if (doctor == null || patient == null)
            {
                return BadRequest("Doctor or Patient not found");
            }

            // Assign Doctor and Patient entities to the Consult
            c.Docter = doctor;
            c.Patient = patient;

            // Add Consult to the context and save changes
            
            await _context.SaveChangesAsync();

            return Ok("Success");
        }

    

    // DELETE: api/Appointments/5
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Consults.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Consults.Remove(appointment);
            await _context.SaveChangesAsync();

         return Ok("Deleted the record");
        }

        private bool AppointmentExists(int id)
        {
            return _context.Consults.Any(e => e.Id == id);
        }
    }
}

