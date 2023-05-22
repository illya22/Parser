
using AngleSharp;
using Newtonsoft.Json;
using Parser.ParserHelpers;

public class Program
{
    public static async Task Main()
    {
        var parser = new SiteParser();
        //for first page
        var url = "https://www.ilcats.ru/toyota/?function=getModels&market=EU";
        var tags = new[] {".id > a", ".name", ".dateRange", ".modelCode" };

        var parsedData = await parser.ParseTagsAsync(url, tags);

       foreach(var key in parsedData)
        {
            Console.WriteLine($"Tag key: {key.Key}");
            Console.WriteLine("Data");
            foreach(var data in key.Value)
            {
                Console.WriteLine(data);
            }
            Console.WriteLine("--------");
        }

        //for second page(table)
        var config = Configuration.Default.WithDefaultLoader();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(url);
        var u = parser.FindLinks(document);
         
        foreach (var ul in u)
        {
            var tabl = await parser.ParseTable(ul);

            foreach (var row in tabl)
            {
                Console.WriteLine(string.Join(", ", row));
            }
        }
        Console.ReadLine();
    }
}