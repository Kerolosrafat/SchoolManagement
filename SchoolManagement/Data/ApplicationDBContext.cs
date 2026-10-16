
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // School - Students
            modelBuilder.Entity<Student>()
                .HasOne(s => s.School)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);

            // School - Teachers
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.School)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);

            // School - Subjects
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.School)
                .WithMany(s => s.Subjects)
                .HasForeignKey(s => s.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);

            // Teacher - Subjects (One-to-Many)
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            // Students - Subjects (Many-to-Many)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Subjects)
                .WithMany(s => s.Students);
        }
    }
}
