using StudentCore.models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.models
{
    public class Student
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Group))]
        public int GroupeId { get; set; }
        public Group? Group { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
