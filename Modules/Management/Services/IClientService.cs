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
        Task<ServiceResponseModel<List<ClientModelDTO>>> GetAll();
        Task<ServiceResponseModel<ClientModelDTO>> GetOne(Guid id);
        Task<ServiceResponseModel<ClientModelDTO>> CreateClient(Request_ClientModel newClient);
        Task<ServiceResponseModel<ClientModelDTO>> UpdateClient(Guid id, Request_ClientModel updatedClient);
        Task<ServiceResponseModel<string>>? DeleteClient(Guid id);
    }
}