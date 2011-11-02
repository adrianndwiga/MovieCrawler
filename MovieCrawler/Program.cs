using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieCrawler.Data;
using MovieCrawler.ProjectFreeTv;
using System.IO;
using System.Net;
using MovieCrawler.Application;

namespace MovieCrawler
{
    class Program
    {
        static void Main()
        {
            var projectFreeTvResultUrls = new ResultUrls();
            projectFreeTvResultUrls.AddRange(new[] {
                "http://www.free-tv-video-online.me/internet/dexter/season_6.html",
                "http://www.free-tv-video-online.me/internet/the_big_bang_theory/season_5.html",
                "http://www.free-tv-video-online.me/internet/the_walking_dead/season_2.html",
                "http://www.free-tv-video-online.me/internet/nikita/season_2.html"});

            var contents = new RequestResults(projectFreeTvResultUrls).Invoke().Contents;
            var movies = new List<MovieDetail>();
            Console.WriteLine("Started Crawling For Movies...");
            foreach(var content in contents){
                movies.AddRange(new ProjectFreeTv.GetResults(content).GetMovies());
            }
            Console.WriteLine("Updating Movies details...");
            foreach (var movie in movies)
            {
                movie.Description = new ProjectFreeTv.SetDetails(new HttpWebRequest(movie.Url).Invoke().Content).GetContent();
            }
            Console.WriteLine("Savings found movies ...");
            new SaveMovies(@"..\..\..\movies.json", movies).Invoke();
            
            Console.WriteLine("Finished...");
        }
    }

    public class RequestResults {
        private readonly ResultUrls _requestUrls;
        public List<string> Contents { get; private set; }

        public RequestResults(ResultUrls requestUrls) {
            _requestUrls = requestUrls;
        }

        public RequestResults Invoke()
        {
            foreach (var url in _requestUrls)
            {
                if (Contents == null)
                    Contents = new List<string>();
                Contents.Add(GetContent(url));
            }
            return this;
        }

        private string GetContent(string url)
        {
            var request = WebRequest.Create(url);
            string content;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var responseReader = new StreamReader(response.GetResponseStream()))
                {
                    content = responseReader.ReadToEnd();
                }
            }
            return content;
        }
    }

    public class HttpWebRequest
    {
        public string Content { get; private set; }
        private readonly string _url;

        public HttpWebRequest(string url)
        {
            _url = url;
        }

        public HttpWebRequest Invoke()
        {
            var request = WebRequest.Create(_url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var responseReader = new StreamReader(response.GetResponseStream()))
                {
                    Content = responseReader.ReadToEnd();
                }
            }
            return this;
        }
    }
}
