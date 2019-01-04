using Factories;
using Services;
using System;
using System.Collections.Generic;

namespace MixcloudBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> paths = new List<String>()
            {
                @"https://www.mixcloud.com/R3MAK/r3mak-best-of-progressive-trance-2018-part-1/",
                @"https://www.mixcloud.com/R3MAK/r3mak-best-of-progressive-trance-2018-part-2/"
            };

            int minGapMilliseconds = 4000;
            int maxGapMilliseconds = 300001;

            Scheduler scheduler = new Scheduler(paths, minGapMilliseconds, maxGapMilliseconds);
            scheduler.Start();

            Console.WriteLine("Boost iniciado");
            Console.WriteLine("Presione ESC para salir");

            ConsoleKey key = Console.ReadKey().Key;

            while (!key.Equals(ConsoleKey.Escape))
            {
                key = Console.ReadKey().Key;
            }

            Console.WriteLine("Saliendo...");
            scheduler.Stop();
        }
    }
}
