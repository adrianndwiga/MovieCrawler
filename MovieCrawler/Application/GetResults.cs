using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieCrawler.Application
{
    public interface IGetResults
    {
        List<MovieDetail> GetMovies();
    }

    public class GetResults 
    {
    }
}
