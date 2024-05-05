namespace StudentCore.models
{
    public class StudentGetAllDto
    {
        public List<StudentGetDto> Students { get; set; }
        public List<Group> Groups { get; set; }
    }
}
