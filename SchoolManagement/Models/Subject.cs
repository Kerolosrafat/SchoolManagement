
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int CreditHours { get; set; }

        public int SchoolId { get; set; }

        public School? School { get; set; }

        // Each subject has one teacher
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        // Many students can enroll in this subject
        public ICollection<Student> Students { get; set; }
            = new List<Student>();
    }
}
