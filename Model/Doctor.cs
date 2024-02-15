using System.ComponentModel.DataAnnotations;

namespace Appointment.Model
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

    }
}
