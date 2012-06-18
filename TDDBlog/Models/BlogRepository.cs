using System.Linq;
using TDDBlog.Data;

namespace TDDBlog.Models
{
    public class BlogRepository
    {
        /// <summary>
        /// Gets all blog entries.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <returns></returns>
        public IQueryable<BlogEntry> GetAllBlogEntries(DataContext dataContext)
        {
            return from x in dataContext.BlogEntries
                   select new BlogEntry()
                              {
                                  Id = x.Id,
                                  Title = x.Title,
                                  Content = x.Content
                              };
        }
    }
}