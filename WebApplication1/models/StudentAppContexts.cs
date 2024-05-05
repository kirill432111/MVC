using Microsoft.EntityFrameworkCore;
using StudentCore.models;

namespace WebApplication1.models
{
    public class StudentAppContexts: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public StudentAppContexts(DbContextOptions<StudentAppContexts> options): base(options) 
        { 

        }

    }

}
