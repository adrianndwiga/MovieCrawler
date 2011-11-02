using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MovieCrawler.ProjectFreeTv;
using System.IO;

namespace MovieCrawler.Tests.ProjectFreeTv
{
    [TestFixture]
    public class GetResultsTests
    {
        [Test]
        public void ShouldLoadAMovie() { 
            var movieHtml = "<td id='t1026296' class=\"mnllinklist dotted\">" +
						"<a onclick='visited(1026296)' href=\"http://www.free-tv-video-online.me/player/divxden.php?id=7la6ayrzcoum\" target=\"_blank\">" +
						"	<div>Bored to Death Season 3 Episode 1</div>" +
					"		<span>" +
					"			Loading Time: <span class='Fast'>Fast</span><br/>" +
					"			Host: vidxden.com<br/>" +
					"			Submitted: 11 October 2011" +
					"		</span>" +
					"	</a>" +
					"	<br/>" +
					"	<a class=\"down\" href=\"http://www.free-tv-video-online.me/downloademule.html\">Download in High Definition with Emule</a>" +
					"</td>";
            var movie = new GetResults(movieHtml).GetMovies()[0];
            Assert.That(movie.Title, Is.StringContaining("Bored to Death Season 3 Episode 1"));
            Assert.That(movie.Url, Is.EqualTo("http://www.free-tv-video-online.me/player/divxden.php?id=7la6ayrzcoum"));

        }

        [Test]
        public void ShouldGetResults() {
            var movies = new GetResults(GetResultsContent("ProjectFreeTvResults.html")).GetMovies();
            Assert.That(movies, Has.Count.EqualTo(34));
            var movie = movies[0];
            Assert.That(movie.Url, Is.EqualTo("http://www.free-tv-video-online.me/player/divxden.php?id=7la6ayrzcoum"));
            Assert.That(movie.Title, Is.EqualTo("Bored to Death Season 3 Episode 1"));
        }

        private string GetResultsContent(string file)
        {
            using (var fileReader = new StreamReader(file))
            {
                return fileReader.ReadToEnd();
            }
        }
    }
}
