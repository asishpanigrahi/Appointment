using Appointment.Model;
using Clinic.Data.dto;
using System.Net.NetworkInformation;

namespace Clinic.Mapper
{
    public class ConsultMapper
    {
        public static Consult ToConsult(ConsultDto d)
        {
            Consult consult = new Consult
            {
                Description = d.Description,
                Id = d.Id,
                StartTime=d.StartTime,
                EndTime=d.EndTime,
                status = d.status,
          
            };
            return consult;
        }

        public static ConsultDto FromConsult(Consult d)
        {
            ConsultDto consult = new ConsultDto
            {
                Description = d.Description,
                Id = d.Id,
                StartTime = d.StartTime,
                EndTime = d.EndTime,
                status = d.status,
             
            };
            return consult;
        }
    }
}
