using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace EmailExtraction2
{
    class Program
        {
        static void Main(string[] args)
        {
            string inputText = File.ReadAllText(@"C:\Training\EmailExtraction2\sample.txt");
            var emailDomainRegex = new Regex(@"\w(@softwire.com)\s+");
            var matches = emailDomainRegex.Matches(inputText);
            int emailCount = 0;

            foreach (Match match in matches)
            {
                emailCount++;
            }
            
            Console.WriteLine($"Number of matches containing @softwire.com: {emailCount}");
        }

    }
}