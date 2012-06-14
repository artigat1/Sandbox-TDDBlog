using System.Collections.Generic;
using System.Web.Mvc;
using TDDBlog.Models;

namespace TDDBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogController"/> class.
        /// </summary>
        /// <param name="iBlogRepository">The i blog repository.</param>
        public BlogController(IBlogRepository iBlogRepository)
        {
            _blogRepository = iBlogRepository;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
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
