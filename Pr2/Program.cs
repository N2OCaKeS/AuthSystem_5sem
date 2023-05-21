using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<string> HostData = new();
        using (StreamReader reader = new("HOSTS.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length == 0 || line[0] == '#')
                    continue;

                string[] parts = line.Split();
                if (parts.Length < 2)
                    continue;

                HostData.Add(parts[1]);
            }
        }

        List<string> LogData = new();
        using (StreamReader reader = new("dns.log"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length == 0 || line[0] == '#')
                    continue;

                string[] parts = line.Split();
                if (parts.Length >= 10)
                    LogData.Add(parts[9]);
            }
        }

        int result = 0;
        foreach (string logData in LogData)
        {
            if (HostData.Contains(logData))
                result++;
        }

        Console.WriteLine("Количество совпадений = " + result);
    }
}
