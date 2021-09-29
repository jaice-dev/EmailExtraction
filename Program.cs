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
            // First Excercise
            
            /*
            string inputText = File.ReadAllText(@"C:\Training\EmailExtraction2\sample.txt");
            var softwireEmailRegex = new Regex(@"\w(@softwire.com)\s+");
            var softwireMatches = softwireEmailRegex.Matches(inputText);
            int emailCount = 0;

            foreach (Match match in softwireMatches)
            {
                emailCount++;
            }
            
            Console.WriteLine($"Number of matches containing @softwire.com: {emailCount}");
            */
            
            // Initialise dictionary of email domains
            Dictionary<string, int> domainDict = new Dictionary<string, int>();

            var allEmailsRegex = new Regex(@"[a-zA-Z0-9-_.]+(@[a-zA-Z0-9-_.]+)\s+");
            var allEmailMatches = allEmailsRegex.Matches(inputText);
            
            // Loop over each match, and add to dictionary if new with value of a
            // new Matches class count for the new domain
            foreach (Match match in allEmailMatches)
            {
                if (!domainDict.ContainsKey(match.Groups[1].Value)) // Groups[1] gets 1st regex group - bit in ()
                {
                    var domainRegex = new Regex(@$"{match.Groups[1].Value}\s+");
                    domainDict[match.Groups[1].Value] = domainRegex.Matches(inputText).Count;
                }
            }
            
            // Loop through dictionary and write contents to console
            foreach (var item in domainDict)
            {
                Console.WriteLine($"Domain: {item.Key} Frequency: {item.Value} ");
            }

        }

    }
}