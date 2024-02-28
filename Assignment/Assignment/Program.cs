using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NotificationParser
{
    class Program
    {
        static readonly List<string> channelTags = new List<string>() { "BE", "FE", "QA", "Urgent" };

        static void Main(string[] args)
        {
            backcase:
            Console.WriteLine("Enter notification title:");
            string title = Console.ReadLine();

            // Extract relevant tags using regular expression
            var matches = Regex.Matches(title, @"\[([^]]+)\]");

            // List identified channels
            List<string> channels = new List<string>();
            foreach (Match match in matches)
            {
                string channelTag = match.Groups[1].Value;
                if (channelTags.Contains(channelTag))
                {
                    channels.Add(channelTag);
                }
            }

            if (channels.Any())
            {
                Console.WriteLine($"Receive channels: {string.Join(", ", channels)}");
            }
            else
            {
                Console.WriteLine("No relevant channels identified.");
            }
            goto backcase;
        }
    }
}