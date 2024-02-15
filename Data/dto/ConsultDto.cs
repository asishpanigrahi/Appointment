using Appointment.Model;

namespace Clinic.Data.dto
{
    public class ConsultDto
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string status { get; set; }
        public int DocterID { get; set; }
        public int PatientID { get; set; }
    }
}
