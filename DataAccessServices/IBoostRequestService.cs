using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataAccessServices
{
    public interface IBoostRequestService
    {
        Task<IList<BoostRequest>> GetRequestBoostsByState(RequestState requestState);
        Task UpdateBoostRequest(BoostRequest boostRequest);
        Task UpdateBoostRequestState(BoostRequest boostRequest, RequestState requestState);
        Task UpdateBoostRequestStates(IList<BoostRequest> boostRequests, RequestState requestState);
    }
}
