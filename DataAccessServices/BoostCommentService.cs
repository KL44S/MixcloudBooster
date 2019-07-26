using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessServices.Factories;
using Microsoft.Extensions.Configuration;
using Model;
using RepositoryAccess;

namespace DataAccessServices
{
    public class BoostCommentService : IBoostCommentService
    {
        private IGetRepository<BoostComment> _getRepository;

        public BoostCommentService(IConfiguration configuration)
        {
            this._getRepository = RepositoryFactory.BuildAndGetGetRepository<BoostComment>(RepositoryFactory.Tech.Mongodb, configuration);
        }

        public async Task<IList<BoostComment>> GetAllBoostComments()
        {
            IList<BoostComment> boostComments = await this._getRepository.GetAllAsync();

            return boostComments;
        }
    }
}
