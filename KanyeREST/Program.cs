using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KanyeREST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest/";
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            Console.WriteLine("Kanye West & Ron Swanson in Conversation!");
            Console.WriteLine("Press any key to begin. Then press 'ESC' to end.");
            Console.ReadKey(true);

            Console.WriteLine("\n\nOkay, here we go...");
 

            while(!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)) 
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var ronResponse = client.GetStringAsync(ronURL).Result;

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                kanyeQuote += '.';
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"',' ').Replace('"',' ').Trim();

                Console.WriteLine("\n");
                System.Threading.Thread.Sleep(4000);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tKANYE:\t" + kanyeQuote);
                System.Threading.Thread.Sleep(2000);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\tRON:\t" + ronQuote);
            }


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nGoodbye!");
            Console.ReadKey(true);
        }
    }
}
