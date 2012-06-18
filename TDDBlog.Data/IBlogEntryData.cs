using System;

namespace TDDBlog.Data
{
    public interface IBlogEntryData
    {
        int Id { get; set; }

        string Title { get; set; }

        string Content { get; set; }

        DateTime? DateCreated { get; set; }
    }
}