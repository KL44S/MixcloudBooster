using Services;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverServices;

namespace Factories
{
    public class MixcloudBoosterFactory
    {
        public static IMixcloudBooster GetBooster()
        {
            WebDriverBooster webDriverBooster = new WebDriverBooster();

            return webDriverBooster;
        }
    }
}
