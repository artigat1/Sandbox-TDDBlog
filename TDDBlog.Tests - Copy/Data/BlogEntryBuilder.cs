using Moq;
using TDDBlog.Models;

namespace TDDBlog.Tests.Data
{
    public class BlogEntryBuilder
    {
        #region Constructor

        private int _id;
        private string _title;
        private string _content;

        private readonly Mock<BlogEntry> _mock;

        public BlogEntryBuilder()
        {
            _mock = new Mock<BlogEntry>();
        }

        #endregion

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>Mocked <see cref="BlogEntry"/> object</returns>
        public BlogEntry Build()
        {
            _mock.SetupGet(b => b.Id).Returns(_id);
            _mock.SetupGet(b => b.Title).Returns(_title);
            _mock.SetupGet(b => b.Content).Returns(_content);

            return _mock.Object;
        }

        #region Setters
        public BlogEntryBuilder WithId(int id)
        {
            _id = id;

            return this;
        }

        public BlogEntryBuilder WithTitle(string title)
        {
            _title = title;

            return this;
        }

        public BlogEntryBuilder WithContent(string content)
        {
            _content = content;

            return this;
        }
        #endregion
    }
}
