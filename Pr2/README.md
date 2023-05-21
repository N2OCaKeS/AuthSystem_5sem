# Сбор и аналитическая обработка информации о сетевом трафике
---
Филиппенко Максим БИСО-02-20

# Цель работы:
---
1. Получить навыки в применении современных инструментов для сбора и анализа информации о сетевом трафике.

2. Изучить методы для предотвращения передачи нежелательного сетевого трафика.

# Ход работы:

1. С помощбю утилиты WireShark собрал сетевой трафик в объеме 272 мегабайта.

![Image alt](https://github.com/N2OCaKeS/AuthSystem_5sem/blob/main/Pr2/screenshots/1.png)

2. Утилитой Zeek вывел метаданные из полученного трафика

3. С GitHub был получен файл с хостам

4. Написан код для сравнения полученных мной данных и данных полученных с GitHub

```C#
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

```
    Количество совпадений = 160
  
