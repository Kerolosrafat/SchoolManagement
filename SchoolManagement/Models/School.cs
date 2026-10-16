
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public string? Phone { get; set; }

        // Relationships
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
