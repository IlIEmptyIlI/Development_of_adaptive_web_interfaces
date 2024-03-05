using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System.Net;

class Program
{
    static void Main()
    {
        // System.Text.RegularExpressions
        string input = "Hello 123 World 456";
        string pattern = @"\d+";
        MatchCollection matches = Regex.Matches(input, pattern);
        Console.WriteLine("Numbers found in the input:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }

        // System.Net
        string url = "https://www.example.com";
        WebClient client = new WebClient();
        string html = client.DownloadString(url);
        Console.WriteLine($"\nContent of the URL '{url}':\n{html}");

        // System.Math
        double radius = 5;
        double area = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine($"\nThe area of a circle with radius {radius} is {area:F2}");

        // System.IO
        string path = @"D:\Универ\3 КУРС\2 семестр\Розробка адаптивних web-інтерфейсів\Laba2\example.txt";
        File.WriteAllText(path, "This is a test file.");
        string content = File.ReadAllText(path);
        Console.WriteLine($"\nContent of the file '{path}':\n{content}");

        // System.Diagnostics
        string pathToExe = @"C:\Windows\System32\notepad.exe";
        try
        {
            Process.Start(pathToExe);
            Console.WriteLine("\nNotepad process started successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nFailed to start Notepad process: {ex.Message}");
        }

        // System.Xml.Linq
        XElement xml = new XElement("root",
            new XElement("child", "value"),
            new XElement("anotherChild", "anotherValue")
        );
        Console.WriteLine("\nXML created:");
        Console.WriteLine(xml);
    }
}