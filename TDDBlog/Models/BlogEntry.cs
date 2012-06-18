using Antix.Data.Entity;

namespace TDDBlog.Models
{
    [DataTable("BlogEntry", Schema = "dbo")]
    [DataIndex("Unique", "Id", IsUnique = true)]
    public class BlogEntry 
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public virtual string Content { get; set; }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        public string Url { get; set; }
    }
}