using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using MovieCrawler.Application;

namespace MovieCrawler.Data
{
    public class SaveMovies
    {
        private readonly List<MovieDetail> _movies;
        private readonly string _file;

        public SaveMovies(string file, List<MovieDetail> movies)
        {
            _movies = movies;
            _file = file;
        }

        public void Invoke()
        {
            var serializer = new DataContractJsonSerializer(typeof(IList<MovieDetail>));
            var stream = new MemoryStream();
            serializer.WriteObject(stream, _movies);
            stream.Flush();
            using (var writer = new FileStream(_file, FileMode.OpenOrCreate))
            {
                var bytes = stream.ToArray();
                foreach (var b in bytes)
                {
                    writer.WriteByte(b);
                }
            }
        }
    }
}
