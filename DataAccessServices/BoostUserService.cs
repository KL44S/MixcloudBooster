using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessServices.Factories;
using Microsoft.Extensions.Configuration;
using Model;
using RepositoryAccess;

namespace DataAccessServices
{
    public class BoostUserService : IBoostUserService
    {
        private IGetRepository<BoostUser> _getRepository;

        public BoostUserService(IConfiguration configuration)
        {
            this._getRepository = RepositoryFactory.BuildAndGetGetRepository<BoostUser>(RepositoryFactory.Tech.Mongodb, configuration);
        }

        public async Task<IList<BoostUser>> GetBoostUsers()
        {
            IList<BoostUser> boostUsers = await this._getRepository.GetAllAsync();

            return boostUsers;
        }
    }
}
