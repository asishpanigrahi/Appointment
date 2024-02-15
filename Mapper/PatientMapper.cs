using Appointment.Model;
using Clinic.Data.dto;

namespace Clinic.Mapper
{
    public class PatientMapper
    {
        public static Patient ToPatient(PatientDto d)
        {
            Patient patient = new Patient
            {
                
                Name = d.Name,
               // Id = d.Id,
            };
            return patient;
        }

        public static PatientDto FromPatient(Patient d)
        {
            PatientDto patient = new PatientDto
            {
                Name = d.Name,
                Id = d.Id,
            };
            return patient;
        }
    }
}
