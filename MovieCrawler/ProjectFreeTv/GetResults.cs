using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using MovieCrawler.Application;

namespace MovieCrawler.ProjectFreeTv
{
    public class GetResults : IGetResults
    {
        private readonly HtmlDocument _htmlDocument;

        public GetResults(string content)
        {
            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(content);
        }

        public List<MovieDetail> GetMovies()
        {
            var nodes = _htmlDocument.DocumentNode.SelectNodes("//td[@class='mnllinklist dotted']");
            var list = new List<MovieDetail>();
            
            foreach(var node in nodes){
                var resultItem = new ResultItem(node);
                var movieDetail = new MovieDetail(resultItem.GetTitleValue(), string.Empty, resultItem.GetUrlValue());
                list.Add(movieDetail);
            }

            return list;
        }
    }

    public class ResultItem : IResultItem {
        private readonly HtmlNode _node;

        public ResultItem(HtmlNode node) {
            _node = node;
        }

        public string GetTitleValue()
        {
            return _node.ChildNodes.FindFirst("div").InnerText;
        }

        public string GetDescriptionValue()
        {
            throw new NotImplementedException();
        }

        public string GetUrlValue()
        {
            return _node.ChildNodes.FindFirst("a").GetAttributeValue("href", string.Empty);
        }
    }
}
