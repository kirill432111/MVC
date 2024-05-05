using StudentCore.models;

namespace Mvc.Models
{
    public class StudentEditViewModel
    {
       public StudentGetDto? Student {  get; set; } 
       public List<Group>? Groups { get; set; }
    }
}
