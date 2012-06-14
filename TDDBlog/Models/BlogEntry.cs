﻿namespace TDDBlog.Models
{
    public class BlogEntry
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Content { get; set; }

        public string Url { get; set; }
    }
}
