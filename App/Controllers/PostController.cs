using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDbContext _context;

        public PostController(BlogDbContext context)
        {
            _context = context;
        }       

        public IActionResult Index()
        {
            var posts = _context.Posts.Include(u => u.Createdby).ThenInclude(c => c.Comments).ToList(); 
                    
            return View(posts);
        }




    }
}
