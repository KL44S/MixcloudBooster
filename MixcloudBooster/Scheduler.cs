using System;
using System.Collections.Generic;
using System.Threading;
using WebDriverServices;

namespace MixcloudBooster
{
    public class Scheduler
    {
        private static IList<string> _paths;
        private static int _minGapMilliseconds;
        private static int _maxGapMilliseconds;
        private static ICloudBooster _mixcloudBooster;
        private static bool _threadMustEnd;
        private static bool _threadIsSleeping;
        private static Thread _thread;
        private static System.Timers.Timer _timer;

        private static void TimeToAwake(object source, System.Timers.ElapsedEventArgs e)
        {
            _threadIsSleeping = false;
            _timer.Dispose();
        }

        private static void SleepThread(int interval)
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = interval;
            _timer.Elapsed += TimeToAwake;
            _timer.Enabled = true;

            _threadIsSleeping = true;
        }

        public Scheduler(IList<string> paths, int minGapMilliseconds, int maxGapMilliseconds)
        {
            _paths = paths;
            _minGapMilliseconds = minGapMilliseconds;
            _maxGapMilliseconds = maxGapMilliseconds;
            //_mixcloudBooster = CloudBoosterFactory.GetBooster();
            _threadMustEnd = false;
            _threadIsSleeping = false;
            _timer = new System.Timers.Timer();
        }

        public void Stop()
        {
            _mixcloudBooster.Dispose();
            _threadMustEnd = true;
            TimeToAwake(null, null);
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
            _threadIsSleeping = false;

            while (!_threadMustEnd)
            {
                try
                {
                    if (!_threadMustEnd && !_threadIsSleeping)
                    {
                        pathRandomIndex = random.Next(_paths.Count);
                        string path = _paths[pathRandomIndex];

                        //_mixcloudBooster.Boost(path);

                        gapMilliseconds = random.Next(_minGapMilliseconds, _maxGapMilliseconds);
                        SleepThread(gapMilliseconds);
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
