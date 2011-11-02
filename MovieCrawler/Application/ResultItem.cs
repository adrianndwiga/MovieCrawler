using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieCrawler.Application
{
    public interface IResultItem
    {
        string GetTitleValue();
        string GetDescriptionValue();
        string GetUrlValue();
    }

    public class ResultItem
    {
    }
}
