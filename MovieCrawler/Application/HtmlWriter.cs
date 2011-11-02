using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MovieCrawler.Application
{
    public class HtmlWriter
    {
        private readonly List<MovieDetail> _movies;
        private readonly string _file;

        public HtmlWriter(string file, List<MovieDetail> movies)
        {
            _movies = movies;
            _file = file;
        }

        public void Save()
        {
            var retVal = new StringBuilder();
            retVal.Append("<html><body>");
            retVal.Append("<h1>Tv Series'</h1>");
            foreach (var movie in _movies)
                retVal.AppendFormat("<div><h2>{0}</h2><p><a href=\"{1}\">{1}</a></p><div>{2}</div></div>", movie.Title, movie.Url, movie.Description);
            retVal.Append("</body></html>");
            using (var writer = new StreamWriter(_file))
            {
                writer.Write(retVal);
            }
        }
    }
}
