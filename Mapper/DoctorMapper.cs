using Appointment.Model;
using Clinic.Data.dto;
using Microsoft.Identity.Client;

namespace Clinic.Mapper
{
    public class DoctorMapper
    {
        public static Doctor Todoctor(DoctorDto d)
        {
            Doctor doctor = new Doctor
            {
                Name = d.Name,
                Specialization=d.Specialization,
              //  Id = d.Id,
            };
            return doctor;
        }

        public static DoctorDto Fromdoctor(Doctor d)
        {
            DoctorDto doctor = new DoctorDto
            {
                Name = d.Name,
                Specialization = d.Specialization,
             //   Id= d.Id,
            };
            return doctor;
        }


    }
}
