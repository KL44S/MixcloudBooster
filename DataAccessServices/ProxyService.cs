using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessServices.Factories;
using Microsoft.Extensions.Configuration;
using Model;
using RepositoryAccess;

namespace DataAccessServices
{
    public class ProxyService : IProxyService
    {
        private IGetRepository<Proxy> _getRepository;
        private IDeleteRepository<Proxy> _deleteRepository;

        public ProxyService(IConfiguration configuration)
        {
            this._getRepository = RepositoryFactory.BuildAndGetGetRepository<Proxy>(RepositoryFactory.Tech.Mongodb, configuration);
            this._deleteRepository = RepositoryFactory.BuildAndGetDeleteRepository<Proxy>(RepositoryFactory.Tech.Mongodb, configuration);
        }

        public async Task<IList<Proxy>> GetProxies()
        {
            IList<Proxy> proxies = await this._getRepository.GetAllAsync();

            return proxies;
        }

        public async Task DeleteProxy(Proxy proxy)
        {
            await this._deleteRepository.DeleteAllByConditionsAsync(x => x.FullPath == proxy.FullPath);
        }
    }
}
