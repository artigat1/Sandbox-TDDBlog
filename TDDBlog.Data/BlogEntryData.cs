using System;
using System.ComponentModel.DataAnnotations;
using Antix.Data.Entity;

namespace TDDBlog.Data
{
    [DataTable("BlogEntries", Schema="dbo")]
    public class BlogEntryData : IBlogEntryData
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        
        public DateTime? DateCreated { get; set; }
    }
}