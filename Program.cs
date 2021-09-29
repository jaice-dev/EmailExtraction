using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace EmailExtraction2
{
    class Program
        {
        static void Main(string[] args)
        {
            string inputText = File.ReadAllText(@"C:\Training\EmailExtraction2\sample.txt");
            var softwireEmailRegex = new Regex(@"\w(@softwire.com)\s+");
            var softwireMatches = softwireEmailRegex.Matches(inputText);
            int emailCount = 0;

            foreach (Match match in softwireMatches)
            {
                emailCount++;
            }
            
            Console.WriteLine($"Number of matches containing @softwire.com: {emailCount}");

            Dictionary<string, int> domainDict = new Dictionary<string, int>();

            var allEmailsRegex = new Regex(@"@[a-zA-Z0-9-_.]+");
            var allEmailMatches = allEmailsRegex.Matches(inputText);

            foreach (Match match in allEmailMatches)
            {
                if (!domainDict.ContainsKey(match.Value))
                {
                    var domainRegex = new Regex(match.Value);
                    domainDict[match.Value] = domainRegex.Matches(inputText).Count;
                }
            }

            foreach (var item in domainDict)
            {
                Console.WriteLine($"Domain: {item.Key} Frequency: {item.Value} ");
            }

        }

    }
}