using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCore.models;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {

        private StudentAppContexts _context;
        public GroupController(StudentAppContexts context)
        {
            _context = context;
        }
        [HttpPut]
        public void Put([FromBody] Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
        }
        [HttpPost]
        public void Post(Group group)
        {
            var Post = _context.Groups.AsNoTracking().FirstOrDefault(x => x.Id == group.Id);
            if (Post != null)
            {
                _context.Groups.Update(group);
                _context.SaveChanges();
            }
        }
        [HttpGet]
        [Route("GetOne")]
        public Group? GetOne(int id)
        {
            return _context.Groups.FirstOrDefault(x => x.Id == id);
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Group> GetAll()
        {
            return _context.Groups.ToList();
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var delete = _context.Groups.FirstOrDefault(x => x.Id == id);
            if (delete != null)
            {
                _context.Groups.Remove(delete);
                _context.SaveChanges();
            }
        }

    }
}
