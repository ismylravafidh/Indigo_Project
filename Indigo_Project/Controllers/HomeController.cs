using Indigo_Project.DAL;
using Indigo_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Indigo_Project.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.ToList();

            return View(posts);
        }
    }
}
