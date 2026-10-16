
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public int SchoolId { get; set; }

        public School? School { get; set; }

        // A student can enroll in many subjects
        public ICollection<Subject> Subjects { get; set; }
            = new List<Subject>();
    }
}
