using Factories;
using Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace MixcloudBooster
{
    public class Scheduler
    {
        private static IList<String> _paths;
        private static int _minGapMilliseconds;
        private static int _maxGapMilliseconds;
        private static IMixcloudBooster _mixcloudBooster;
        private static Boolean _threadMustEnd;
        private static Thread _thread;

        public Scheduler(IList<String> paths, int minGapMilliseconds, int maxGapMilliseconds)
        {
            _paths = paths;
            _minGapMilliseconds = minGapMilliseconds;
            _maxGapMilliseconds = maxGapMilliseconds;
            _mixcloudBooster = MixcloudBoosterFactory.GetBooster();
            _threadMustEnd = false;
        }

        public void Stop()
        {
            _mixcloudBooster.Dispose();
            _threadMustEnd = true;
        }

        public void Start()
        {
            _thread = new Thread(Schedule);
            _thread.Start();
        }

        public static void Schedule()
        {
            int gapMilliseconds = 0;
            int pathRandomIndex = 0;
            Random random = new Random();
            _threadMustEnd = false;

            while (!_threadMustEnd)
            {
                try
                {
                    pathRandomIndex = random.Next(_paths.Count);
                    String path = _paths[pathRandomIndex];

                    _mixcloudBooster.Boost(path);

                    if (!_threadMustEnd)
                    {
                        gapMilliseconds = random.Next(_minGapMilliseconds, _maxGapMilliseconds);
                        Thread.Sleep(gapMilliseconds);
                    }

                }
                catch (Exception) { }
            }
        }
    }
}
