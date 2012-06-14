using System.Collections.Generic;

namespace TDDBlog.Models
{
    public interface IBlogRepository
    {
        IEnumerable<BlogEntry> GetAllBlogEntries();
    }
}
