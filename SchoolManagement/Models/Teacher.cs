
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public int SchoolId { get; set; }

        public School? School { get; set; }

        // One teacher teaches many subjects
        public ICollection<Subject> Subjects { get; set; }
            = new List<Subject>();
    }
}
