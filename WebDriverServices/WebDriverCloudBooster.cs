using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using WebDriverServices.Utils;

namespace WebDriverServices
{
    public abstract class WebDriverCloudBooster : WebDriverBooster, ICloudBooster
    {
        protected IPlayBoost _playBooster;
        protected IShareBoost _shareBooster;
        protected ILikeBoost _likeBooster;
        protected IFollowBoost _followBooster;
        
        protected abstract Task Boost(WebAction action, string trackPath);

        public async Task Boost(string trackPath, IList<WebAction> actions)
        {
            if (this._webDriver != null)
            {
                SeleniumUtils.NavigateTo(this._webDriver, trackPath);
            }

            Task[] boosts = new Task[actions.Count];

            for (int i = 0; i < actions.Count; i++)
            {
                WebAction action = actions[i];
                boosts[i] = this.Boost(action, trackPath);
            }

            await Task.WhenAll(boosts);
        }

        public void Dispose()
        {
            if (this._webDriver != null)
            {
                this._webDriver.Quit();
            }
        }
    }
}
