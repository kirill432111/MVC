using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCore.models;
using WebApplication1.Migrations;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {

        private StudentAppContexts _context;
        public StudentController(StudentAppContexts context)   
        {
            _context = context;
        }
        [HttpPut]
        public void Put([FromBody] StudentAddDto model)
        {
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,  
                GroupeId = model.GroupeId,
                Email = model.Email,
                Password = model.Password,
                CreatedAt = DateTime.Now
            };
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        [HttpPost]
        public void Post(StudentEditDto student)
        {
            var Post = _context.Students.FirstOrDefault(x => x.Id == student.Id);
            if (Post != null)
            {
                Post.FirstName = student.FirstName;
                Post.LastName = student.LastName;
                Post.GroupeId = student.GroupeId;
                Post.UpdatedAt = DateTime.Now;
                _context.Students.Update(Post);
                _context.SaveChanges();
            }
        }
        [HttpGet]
        [Route("GetOne")]
        public StudentGetDto? GetOne(int id)
        {
            var student = _context.Students.Include(p => p.Group).FirstOrDefault(x => x.Id == id);
            if (student == null) return null;
            return StudentGetDto(student);
        }
        [HttpGet]
        [Route("GetAll")]
        public StudentGetAllDto GetAll()
        {
            var model = new StudentGetAllDto
            {
                Students =_context.Students
                    .ToList()
                    .Select(student => StudentGetDto(student))
                    .ToList(),
                Groups = _context.Groups.ToList()
            };
            
            return model;
        }
        private StudentGetDto StudentGetDto(Student student)
        {
            return new StudentGetDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                GroupeId = student.GroupeId,
                Group = student.Group,
                CreatedAt = student.CreatedAt,
                UpdatedAt = student.UpdatedAt,
                Password = student.Password
            };
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var delete = _context.Students.FirstOrDefault(x => x.Id == id);
            if (delete != null)
            {
                _context.Students.Remove(delete);
                _context.SaveChanges();
            }
        }

    }
}
