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
    public class SetDetailsTests
    {
        [Test]
        public void ShouldExtractDetails()
        {
            string _details = GetFileContent("ProjectFreeTvDetails.html");
            var setDetails = new SetDetails(_details);
            Assert.That(setDetails.GetContent(), Is.StringContaining("<iframe></iframe>"));
        }

        private string GetFileContent(string file)
        {
            using (var fileReader = new StreamReader(file)) {
                return fileReader.ReadToEnd();
            }
        }
    }
}
