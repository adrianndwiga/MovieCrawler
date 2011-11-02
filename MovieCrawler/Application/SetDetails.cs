using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieCrawler.Application
{
    public interface ISetDetails
    {
        string GetContent();
    }

    public class SetDetails : ISetDetails
    {
        public string GetContent()
        {
            throw new NotImplementedException();
        }
    }
}
