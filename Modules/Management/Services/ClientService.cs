using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Data;
using therapyFlow.Modules.Common.Models;
using therapyFlow.Modules.Management.Models;

namespace therapyFlow.Modules.Management.Services
{
    public class ClientService : IClientService
    {
        private readonly DataContext _context;

        public ClientService(DataContext context)
        {
            _context = context;
        }
        public Task<ServiceResponseModel<ClientModel>> CreateClient(Request_ClientModel newClient)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel<string>>? DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel<List<ClientModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel<ClientModel>> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel<ClientModel>> UpdateClient(int id, Request_ClientModel updatedClient)
        {
            throw new NotImplementedException();
        }
    }
}