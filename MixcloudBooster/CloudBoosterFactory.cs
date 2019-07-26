using Model;
using WebDriverServices;
using WebDriverServices.Mixcloud;

namespace MixcloudBooster
{
    public class CloudBoosterFactory
    {
        public static ICloudBooster GetBooster(Plataform plataform)
        {
            ICloudBooster webDriverBooster = null;

            switch (plataform)
            {
                case Plataform.Mixcloud:
                    webDriverBooster = new MixcloudWebDriverBooster(ConfigurationFactory.GetConfiguration());
                    break;

                case Plataform.Soundcloud:
                    //webDriverBooster = new SoundcloudWebDriverBooster();
                    break;
            }

            return webDriverBooster;
        }
    }
}
