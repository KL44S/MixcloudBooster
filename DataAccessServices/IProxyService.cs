using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataAccessServices
{
    public interface IProxyService
    {
        Task<IList<Proxy>> GetProxies();
        Task DeleteProxy(Proxy proxy);
    }
}
