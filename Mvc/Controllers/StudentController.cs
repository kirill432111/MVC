using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using StudentCore.models;

namespace Mvc.Controllers
{
    public class StudentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using HttpClient client = new HttpClient();
            var model = await client.GetFromJsonAsync<StudentGetAllDto>("http://localhost:5301/Student/GetAll");
            return View(model);
        }
        public async Task<IActionResult> Delete(int id  )
        {
            using HttpClient client = new HttpClient();
            var model = await client.DeleteAsync($"http://localhost:5301/Student?id={id}");
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Add(StudentAddDto student)
        {
            using HttpClient client = new HttpClient();

            
            await client.PutAsJsonAsync($"http://localhost:5301/Student", student);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            using HttpClient client = new HttpClient();
            var model = await client.GetFromJsonAsync<List<Group>>("http://localhost:5301/Group/GetAll");
            return View(model);
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentEditDto student)
        {
            using HttpClient client = new HttpClient();
       
            await client.PostAsJsonAsync($"http://localhost:5301/Student", student);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using HttpClient client = new HttpClient();
            var model = new StudentEditViewModel
            {
                Student = await client.GetFromJsonAsync<StudentGetDto>($"http://localhost:5301/Student/GetOne?id={id}"),
                Groups = await client.GetFromJsonAsync<List<Group>>("http://localhost:5301/Group/GetAll")
            };

            return View(model);
        }
    }
}
