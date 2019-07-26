using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataAccessServices
{
    public interface IBoostUserService
    {
        Task<IList<BoostUser>> GetBoostUsers();
    }
}
