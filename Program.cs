using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text.Encodings.Web;
using System.Xml;
using System.IO;
using HtmlAgilityPack;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using TestApp.Model;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string html = string.Empty;
            //Dictionary<string, int>

            using (WebClient client = new WebClient())
            {
                html = client.DownloadString("https://covid.hespress.com");
            }

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            HtmlNode regiondTable = doc.DocumentNode.SelectSingleNode("//table[@class='table table-sm table-striped']");
            HtmlNodeCollection regionNames = regiondTable.SelectNodes("//tr/th/a");
            HtmlNodeCollection regionCases = regiondTable.SelectNodes("//tr/td[not(@style)]");
            HtmlNodeCollection newRegionCases = regiondTable.SelectNodes("//tr/td[@style]");

            IEnumerable<Region> regions = JsonConvert.DeserializeObject<IEnumerable<Region>>(File.ReadAllText("Data/regions.json", Encoding.UTF8).ToString());

            for(int i = 0; i < 12; i++)
            {
                Console.WriteLine(regions.FirstOrDefault(r => r.ArabicName.Equals(regionNames[i].InnerText)).EnglishName
                     + " : " + regionCases[i].InnerText + " | Today's case : " + newRegionCases[i].InnerText);
            }

            Console.ReadKey();
        }
    }

    class Boa
    {
        public string Code_boa { get; set; }
    }

    class Refund
    {
        public string RefundId { get; set; }
    }
}
