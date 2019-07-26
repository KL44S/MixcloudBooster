using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataAccessServices
{
    public interface IBoostCommentService
    {
        Task<IList<BoostComment>> GetAllBoostComments();
    }
}
