using System.Collections.Generic;
using System.Web.Mvc;
using TDDBlog.Models;

namespace TDDBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository iBlogRepository)
        {
            _blogRepository = iBlogRepository;
        }

        public ViewResult Index()
        {
            var blogEntries = _blogRepository.GetAllBlogEntries();
            
            foreach (var blogEntry in blogEntries)
            {
                blogEntry.Url = blogEntry.Title
                    .Replace("'", string.Empty)
                    .Replace("!", string.Empty)
                    .Replace(" ", "-")
                    .ToLower();
            }

            return View(blogEntries);
        }
    }
}
