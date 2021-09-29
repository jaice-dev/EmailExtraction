using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace EmailExtraction2
{
    class Program
        {
        static void Main(string[] args)
        {
            var inputText = File.ReadAllText(@"C:\Training\EmailExtraction2\sample.txt");
             
            // First Excercise
             /*
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

            var regexString = @"[a-zA-Z0-9-_.]+(@[a-zA-Z0-9-_.]+)\s+";
            var allEmailsRegex = new Regex(regexString);
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
            var counter = 0;
            var maxDomainsNum = 10;
            var minFrequency = 1;
            
            foreach (var item in domainDict.OrderBy(key => key.Value).Reverse())
            {
                if (counter >= maxDomainsNum || item.Value <= minFrequency)
                {
                    break;
                }
                
                Console.WriteLine($"Domain: {item.Key} Frequency: {item.Value} ");
                counter++;
            }
            
            // Phone Number Validation
            // (?:\+\d\d\s?)|0[0-9]{4}\s?[0-9]{6}

        }

    }
}