using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.ParserHelpers
{
    public class SiteParser
    {
        //metold to parse pages, depending on tag or tags
        public async Task<Dictionary<string, List<string>>> ParseTagsAsync(string url, params string[] tags)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(url);
            var parsedData = new Dictionary<string, List<string>>();




            foreach (var tag in tags)
            {
                var tagElements = document.QuerySelectorAll(tag);
                var tagValues = tagElements.Select(element => element.InnerHtml.Trim());
                parsedData.Add(tag, tagValues.ToList());
            }

            return parsedData;
        }

        // metold to parse table
        public async Task<List<List<string>>> ParseTable(string url)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url);
            var table = document.QuerySelector("tbody");

            var tableData = new List<List<string>>();

            var linkUrls = FindLinks(document);

            //skip header
            var rows = table.QuerySelectorAll("tr").Skip(1);


            foreach (var row in rows)
            {
                var rowData = new List<string>();
                                             //take only needed tag
                foreach (var cell in row.QuerySelectorAll("td").Skip(2).Take(8))
                {
                    var div = cell.QuerySelector("div");

                    if (div != null)
                    {
                        var value = div.InnerHtml;
                        rowData.Add(value);
                    }
                    else
                    {
                        rowData.Add("N/A");
                    }
                }

                tableData.Add(rowData);

            }

            return tableData;
        }

        //metold with finds links
        public List<string> FindLinks(IDocument document)
        {
            var linkUrls = new List<string>();
            //take only complectations links with are in tag a
            var linkElements = document.QuerySelectorAll("a").Skip(5).Take(208); 
            foreach (var linkElement in linkElements)
            {
                var linkUrl = linkElement.GetAttribute("href");
                //create new link
                var absoluteUrl = new Uri(new Uri("https://www.ilcats.ru/"), linkUrl).AbsoluteUri;
                linkUrls.Add(absoluteUrl);
            }

            return linkUrls;
        }
    }
}
