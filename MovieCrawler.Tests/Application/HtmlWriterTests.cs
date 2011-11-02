using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MovieCrawler.Application;
using System.IO;

namespace MovieCrawler.Tests.Application
{
    [TestFixture]
    public class HtmlWriterTests
    {
        [Test]
        public void ShouldSaveMovies() {
            List<MovieDetail> movies = new List<MovieDetail>();
            var movie = new MovieDetail("Movie 1", "<p>My Movie</p>", "http//My/Movie/Detail/Url");
            movies.Add(movie);
            new HtmlWriter("default.html", movies).Save();
            var fileContent = File.ReadAllText("default.html");
            Assert.That(fileContent, Is.StringContaining(movie.Title));
            Assert.That(fileContent, Is.StringContaining(movie.Url));
            File.Delete("default.html");
        }
    }
}
