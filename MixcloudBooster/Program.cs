using System.Collections.Generic;
using Model;
using WebDriverServices.Soundcloud;

namespace MixcloudBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            //MixcloudWebDriverBooster booster = new MixcloudWebDriverBooster();
            //booster.Boost(@"https://soundcloud.com/r-3-m-a-k/ed-sheeran-castle-on-the-hill-nwyr-remix-r3mak-re-edit", new List<WebAction>() { WebAction.Like });
            //booster.Dispose();

            SoundcloudWebDriverBooster booster = new SoundcloudWebDriverBooster(ConfigurationFactory.GetConfiguration());
            booster.Boost(@"https://soundcloud.com/r-3-m-a-k/zedd-feat-hayley-williams-stay-the-night-r3mak-bootleg-remix",
                new List<WebAction>() { WebAction.Play }).GetAwaiter().GetResult();
            booster.Dispose();
            //List<string> paths = new List<string>()
            //{
            //    @"https://www.mixcloud.com/R3MAK/r3mak-best-of-progressive-trance-2018-part-1/",
            //    @"https://www.mixcloud.com/R3MAK/r3mak-best-of-progressive-trance-2018-part-2/"
            //};

            //int minGapMilliseconds = 4000;
            //int maxGapMilliseconds = 300001;

            //Scheduler scheduler = new Scheduler(paths, minGapMilliseconds, maxGapMilliseconds);
            //scheduler.Start();

            //Console.WriteLine("Boost iniciado");
            //Console.WriteLine("Presione ESC para salir");

            //ConsoleKey key;

            //do
            //{
            //    key = Console.ReadKey().Key;

            //} while (!key.Equals(ConsoleKey.Escape));

            //Console.SetCursorPosition(0, Console.CursorTop - 1);
            //Console.WriteLine("");
            //Console.WriteLine("Saliendo...");

            //scheduler.Stop();
        }
    }
}
