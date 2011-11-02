using System.Runtime.Serialization;

namespace MovieCrawler.Application
{
    [DataContract]
    public class MovieDetail
    {
        public MovieDetail(string title, string description, string url)
        {
            Title = title;
            Description = description;
            Url = url;
        }

        [DataMember]
        public string Title { get; private set; }

        [DataMember]
        public string Url { get; private set; }

        [DataMember]
        public string Description { get; set; }
    }
}
