using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieCrawler.Application;
using HtmlAgilityPack;

namespace MovieCrawler.ProjectFreeTv
{
    public class SetDetails : ISetDetails
    {
        private readonly HtmlDocument _htmlDocument;

        public SetDetails(string content) {
            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(content);
        }
        public string GetContent()
        {
            var htmlNode = _htmlDocument.DocumentNode.SelectNodes("//td[@class='mnlhighlightheading']/div/table/tr/td/div")[1];
            return htmlNode.InnerHtml;
        }
    }
}
