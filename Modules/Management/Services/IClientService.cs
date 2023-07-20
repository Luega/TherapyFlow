using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Modules.Common.Models;
using therapyFlow.Modules.Management.Models;

namespace therapyFlow.Modules.Management.Services
{
    public interface IClientService
    {
        Task<ServiceResponseModel<List<ClientModel>>> GetAll();
        Task<ServiceResponseModel<ClientModel>> GetOne(int id);
        Task<ServiceResponseModel<ClientModel>> CreateClient(Request_ClientModel newClient);
        Task<ServiceResponseModel<ClientModel>> UpdateClient(int id, Request_ClientModel updatedClient);
        Task<ServiceResponseModel<string>>? DeleteClient(int id);
    }
}