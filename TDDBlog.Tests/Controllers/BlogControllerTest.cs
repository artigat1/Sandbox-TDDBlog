using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TDDBlog.Models;
using TDDBlog.Tests.Data;
using TDDBlog.Controllers;

namespace TDDBlog.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTest
    {
        [TestMethod]
        public void IndexReturnsAListOfBlogEntriesWithCorrectUrls()
        {
            const int id1 = 1;
            const string title1 = "My first blog Entry";
            const string content1 = "I love blogging, it is so cool";
            var mockBlogEntry1 = new BlogEntryBuilder()
                .WithId(id1)
                .WithTitle(title1)
                .WithContent(content1)
                .Build();

            const int id2 = 2;
            const string title2 = "I'm still in to this";
            const string content2 = "I'm still enjoying my blogging";
            var mockBlogEntry2 = new BlogEntryBuilder()
                .WithId(id2)
                .WithTitle(title2)
                .WithContent(content2)
                .Build();

            const int id3 = 3;
            const string title3 = "OK!";
            const string content3 = "Ok, I'm done!";
            var mockBlogEntry3 = new BlogEntryBuilder()
                .WithId(id3)
                .WithTitle(title3)
                .WithContent(content3)
                .Build();

            var blogRepository = new Mock<IBlogRepository>();
            blogRepository.Setup(x => x.GetAllBlogEntries())
                .Returns(new List<BlogEntry>
                             {
                                 mockBlogEntry1,
                                 mockBlogEntry2,
                                 mockBlogEntry3
                             });

            var blogController = new BlogController(blogRepository.Object);

            var viewResult = blogController.Index();

            var blogEntries = (List<BlogEntry>)viewResult.ViewData.Model;

            var blogEntry1 = blogEntries[0];
            Assert.AreEqual(id1, blogEntry1.Id);
            Assert.AreEqual(title1, blogEntry1.Title);
            Assert.AreEqual(content1, blogEntry1.Content);
            const string url1 = "my-first-blog-entry";
            Assert.AreEqual(url1, blogEntry1.Url);

            var blogEntry2 = blogEntries[1];
            Assert.AreEqual(id2, blogEntry2.Id);
            Assert.AreEqual(title2, blogEntry2.Title);
            Assert.AreEqual(content2, blogEntry2.Content);
            const string url2 = "Im-still-in-to-this";
            Assert.AreNotEqual(url2, blogEntry2.Url);
            const string url2A = "im-still-in-to-this";
            Assert.AreEqual(url2A, blogEntry2.Url);

            var blogEntry3 = blogEntries[2];
            Assert.AreEqual(id3, blogEntry3.Id);
            Assert.AreEqual(title3, blogEntry3.Title);
            Assert.AreEqual(content3, blogEntry3.Content);
            const string url3 = "ok";
            Assert.AreEqual(url3, blogEntry3.Url);
        }
    }
}
