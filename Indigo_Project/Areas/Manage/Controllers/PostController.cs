using Indigo_Project.Areas.Manage.ViewModels;
using Indigo_Project.DAL;
using Indigo_Project.Helpers;
using Indigo_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Indigo_Project.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PostController : Controller
    {
        AppDbContext _context;
        IWebHostEnvironment _env;
        public PostController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.ToList();
            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!post.ImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError("ImageFile", "Yalniz sekil yukluye bilersen");
                return View();
            }
            post.ImgUrl = post.ImageFile.Upload(_env.WebRootPath, @"\Upload\PostImage\");
            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Post post = _context.Posts.Find(id);


            UpdatePostVm updatePostVm = new UpdatePostVm()
            {
                Id = post.Id,
                Title=post.Title,
                Description=post.Description,
                ImgUrl=post.ImgUrl,
            };

            return View(updatePostVm);
        }
        [HttpPost]
        public IActionResult Update(UpdatePostVm newPost)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Post oldPost = _context.Posts.Where(p => p.Id == newPost.Id).FirstOrDefault();
            oldPost.Title = newPost.Title;
            oldPost.Description = newPost.Description;
            if (newPost.ImageFile != null)
            {
                if (!newPost.ImageFile.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("ImageFile", "Yalniz sekil yukluye bilersen");
                    return View();
                }
                newPost.ImgUrl = newPost.ImageFile.Upload(_env.WebRootPath, @"\Upload\PostImage\");
                oldPost.ImgUrl = newPost.ImgUrl;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Post post = _context.Posts.Find(id);
            _context.Posts.RemoveRange(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
