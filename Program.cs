using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Covid
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://www.health.state.mn.us/diseases/coronavirus/situation.html");
            result.EnsureSuccessStatusCode();

            var html = await result.Content.ReadAsStringAsync();

            Console.Out.WriteLine($"Positive: {GetPositiveCount(html)}");

            Console.Out.WriteLine($"---");

            Console.Out.WriteLine($"Deaths: {GetDeathCount(html)}");
            Console.Out.WriteLine($"Last Updated: {GetLastUpdated(html)}");

            Console.Out.WriteLine($"---");
            Console.Out.WriteLine($"MN DOH | href=https://www.health.state.mn.us/diseases/coronavirus/situation.html");

            return 1;
        }

        static int GetPositiveCount(string html){
            var match = Regex.Match(html,"<strong>Total positive: </strong>(.*)</p>");
            if(!match.Success || match.Groups.Count != 2)
                return 0;

            return int.Parse(match.Groups[1].Value.Replace(",",""));
        }

        static int GetDeathCount(string html){
            var match = Regex.Match(html,"<strong>Deaths:</strong> (.*)</li>");
            if(!match.Success || match.Groups.Count != 2)
                return 0;

            return int.Parse(match.Groups[1].Value);
        }

        static string GetLastUpdated(string html){
            var match = Regex.Match(html,"<strong>Updated (.*) </strong>");
            if(!match.Success || match.Groups.Count != 2)
                return "N/A";

            return match.Groups[1].Value;
        }
    }
}
