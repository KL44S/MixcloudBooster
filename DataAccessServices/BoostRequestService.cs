using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessServices.Factories;
using Microsoft.Extensions.Configuration;
using Model;
using RepositoryAccess;

namespace DataAccessServices
{
    public class BoostRequestService : IBoostRequestService
    {
        private IGetRepository<BoostRequest> _getRepository;
        private ISaveRepository<BoostRequest> _saveRepository;

        public BoostRequestService(IConfiguration configuration)
        {
            this._getRepository = RepositoryFactory.BuildAndGetGetRepository<BoostRequest>(RepositoryFactory.Tech.Mongodb, configuration);
            this._saveRepository = RepositoryFactory.BuildAndGetSaveRepository<BoostRequest>(RepositoryFactory.Tech.Mongodb, configuration);
        }

        public async Task<IList<BoostRequest>> GetRequestBoostsByState(RequestState requestState)
        {
            IList<BoostRequest> boostRequests = await this._getRepository.GetAllByConditionsAsync(x => x.RequestState == requestState);

            return boostRequests;
        }

        public async Task UpdateBoostRequest(BoostRequest boostRequest)
        {
            await this._saveRepository.UpdateAsync(x => x.RequestId == boostRequest.RequestId, boostRequest);
        }

        public async Task UpdateBoostRequestState(BoostRequest boostRequest, RequestState requestState)
        {
            boostRequest.RequestState = requestState;
            await this.UpdateBoostRequest(boostRequest);
        }

        public async Task UpdateBoostRequestStates(IList<BoostRequest> boostRequests, RequestState requestState)
        {
            Task[] tasks = new Task[boostRequests.Count];

            for (int i = 0; i < boostRequests.Count; i++)
            {
                BoostRequest boostRequest = boostRequests[i];
                tasks[i] = this.UpdateBoostRequestState(boostRequest, requestState);
            }

            await Task.WhenAll(tasks);
        }
    }
}
