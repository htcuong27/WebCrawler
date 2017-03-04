using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start crawler...");

            //GET : https://tiki.vn/ 
            TinTrinhLibrary.WebClient client = new TinTrinhLibrary.WebClient();
            //get book
            for (int i = 1; i <= 4; i++)
            {
                string html = client.Get("https://tiki.vn/bestsellers/sach-truyen-tieng-viet/c316?p="+i+"", "http://tiki.vn/", "");
                //get book
                MatchCollection book = Regex.Matches(html, "title=\"(.*?)\" data-brand", RegexOptions.Multiline);
                foreach (Match title in book)
                    Console.WriteLine(title.Groups[1].Value.Replace("?", "").Trim());
                //get author
                MatchCollection authors = Regex.Matches(html, "author\">(.*?)</p>", RegexOptions.Singleline);
                foreach (Match author in authors)
                    Console.WriteLine(author.Groups[1].Value.Replace("?", "").Trim());
                //get price
                MatchCollection priceList = Regex.Matches(html, "price-sale\">(.*?)<span", RegexOptions.Singleline);
                foreach (Match price in priceList)
                    Console.WriteLine(price.Groups[1].Value.Replace("?", "").Trim());
                //get comment
                MatchCollection comments = Regex.Matches(html, "review\">(.*?)</p>", RegexOptions.Multiline);
                foreach (Match review in comments)
                    Console.WriteLine(review.Groups[1].Value.Replace("?", "").Trim());
                //get description
                MatchCollection descriptions = Regex.Matches(html, "description\">(.*?)<a", RegexOptions.Singleline);
                foreach (Match description in descriptions)
                    Console.WriteLine(description.Groups[1].Value.Replace("?", "").Trim());
            }
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("OK");
            Console.ReadLine();
        }
    }
}
