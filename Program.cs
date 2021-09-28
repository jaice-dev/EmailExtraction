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
            string sampleString = File.ReadAllText(@"C:\Training\EmailExtraction2\sample.txt");
            var emailRegex = new Regex(@"\w(@softwire.com)\s+");
            var matches = emailRegex.Matches(sampleString);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }

        }

    }
}