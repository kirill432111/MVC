using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCore.models
{
    public class StudentEditDto
    {
        public int Id { get; set; }
        public int GroupeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
