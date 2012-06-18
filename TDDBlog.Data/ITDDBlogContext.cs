using System.Linq;

namespace TDDBlog.Data
{
   public  interface ITddBlogContext : ICoreUnitOfWork
    {
       IQueryable<IBlogEntryData> BlogEntries { get; }
    }
}
