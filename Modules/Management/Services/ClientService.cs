using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceResponseModel<ClientModel>> CreateClient(Request_ClientModel newClient)
        {
            ServiceResponseModel<ClientModel> serviceResponse = new ServiceResponseModel<ClientModel>();

            var lastId = await _context.Clients.OrderByDescending(client => client.Id).FirstOrDefaultAsync();
            int nextId = 1;
            if (lastId != null)
            {
                nextId = lastId.Id + 1;
            }

            ClientModel client = new ClientModel { 
                Id = nextId,
                FirstName = newClient.FirstName,
                LastName = newClient.LastName,
             };
            
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Clients.FindAsync(nextId);

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<string>>? DeleteClient(int id)
        {
            ServiceResponseModel<String> serviceResponse = new ServiceResponseModel<String>();

            try
            {
                var clientFromDB = await _context.Clients.FindAsync(id);
                if (clientFromDB is null) 
                {
                    throw new Exception($"Id {id} not found.");
                }

                _context.Clients.Remove(clientFromDB);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            serviceResponse.Data = "Client deleted successfully";

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<List<ClientModel>>> GetAll()
        {
            ServiceResponseModel<List<ClientModel>> serviceResponse = new ServiceResponseModel<List<ClientModel>>();
            serviceResponse.Data = await _context.Clients.ToListAsync();
            
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<ClientModel>> GetOne(int id)
        {
            ServiceResponseModel<ClientModel> serviceResponse = new ServiceResponseModel<ClientModel>();
            
            try
            {
                var clientFromDB = await _context.Clients.FindAsync(id);
                if (clientFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                serviceResponse.Data = clientFromDB;
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<ClientModel>> UpdateClient(int id, Request_ClientModel updatedClient)
        {
            ServiceResponseModel<ClientModel> serviceResponse = new ServiceResponseModel<ClientModel>();
            
            try
            {
                var clientFromDB = await _context.Clients.FindAsync(id);
                if (clientFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                clientFromDB.FirstName = updatedClient.FirstName;
                clientFromDB.LastName = updatedClient.LastName;
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Clients.FindAsync(id);
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}