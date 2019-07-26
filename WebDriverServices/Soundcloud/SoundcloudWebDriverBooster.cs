using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessServices;
using Microsoft.Extensions.Configuration;
using Model;
using WebDriverServices.Factories;

namespace WebDriverServices.Soundcloud
{
    public class SoundcloudWebDriverBooster : WebDriverCloudBooster, IFollowBoost, ILikeBoost, IPlayBoost, IShareBoost
    {
        private Task _createBoostersTask;

        public SoundcloudWebDriverBooster(IConfiguration configuration)
        {
            this._createBoostersTask = this.CreateBoosters(configuration);
        }

        public async Task Follow(string trackPath)
        {
            await this._createBoostersTask;
            await this._followBooster.Follow(trackPath);
        }

        public async Task Like(string trackPath)
        {
            await this._createBoostersTask;
            await this._likeBooster.Like(trackPath);
        }

        public async Task Play(string trackPath)
        {
            await this._createBoostersTask;
            await this._playBooster.Play(trackPath);
        }

        public async Task Share(string trackPath)
        {
            await this._createBoostersTask;
            await this._shareBooster.Share(trackPath);
        }

        protected override async Task Boost(WebAction action, string trackPath)
        {
            switch (action)
            {
                case WebAction.Play:
                    await this.Play(trackPath);
                    break;

                case WebAction.Follow:
                    await this.Follow(trackPath);
                    break;

                case WebAction.Like:
                    await this.Like(trackPath);
                    break;

                case WebAction.Share:
                    await this.Share(trackPath);
                    break;
            }
        }

        private async Task CreateBoosters(IConfiguration configuration)
        {
            IBoostUserService boostUserService = BoostUserServiceFactory.BuildAndGetBoostUser(configuration);
            IList<BoostUser> boostUsers = await boostUserService.GetBoostUsers();

            BoostUser boostUser = boostUsers[2];

            this._playBooster = new SoundcloudPlayBooster(this._webDriver, configuration);
            //this._followBooster = new MixcloudFollowBooster(this._webDriver);
            //this._shareBooster = new MixcloudShareBooster(this._webDriver);

            //SoundcloudLikeBooster likeBooster = new SoundcloudLikeBooster(this._webDriver);
            //likeBooster.BoostUser = boostUser;
            //this._likeBooster = likeBooster;
        }
    }
}
