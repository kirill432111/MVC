using Microsoft.AspNetCore.Mvc;
using StudentCore.models;

namespace Mvc.Controllers
{
    public class GroupController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using HttpClient client = new HttpClient();
            var model = await client.GetFromJsonAsync<List<Group>>("http://localhost:5301/Group/GetAll");
            return View(model);
        }
        public async Task<IActionResult> Delete(int id  )
        {
            using HttpClient client = new HttpClient();
            var model = await client.DeleteAsync($"http://localhost:5301/Group?id={id}");
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Add(string name)
        {
            using HttpClient client = new HttpClient();
            var group = new Group { Name = name };
            await client.PutAsJsonAsync("http://localhost:5301/Group", group);
            return RedirectToAction(nameof(Index)); 
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string name, int id)
        {
            using HttpClient client = new HttpClient();
            var group = new Group { Id = id, Name = name };
            await client.PostAsJsonAsync("http://localhost:5301/Group", group);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using HttpClient client = new HttpClient();
            var model = await client.GetFromJsonAsync<Group>($"http://localhost:5301/Group/GetOne?id={id}");

            return View(model);
        }
    }
}
