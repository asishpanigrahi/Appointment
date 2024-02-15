namespace Appointment.Model
{
    public class Consult
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime {  get; set; }
        public DateTime EndTime { get; set; }
        public string status { get; set; }
        public Doctor Docter { get; set; }
        public Patient Patient { get; set; }
        

    }
}
