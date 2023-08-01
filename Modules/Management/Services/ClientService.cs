using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using therapyFlow.Data;
using therapyFlow.Modules.Common.Models;
using therapyFlow.Modules.Management.Mappers;
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

        public async Task<ServiceResponseModel<ClientModelDTO>> CreateClient(Request_ClientModel newClient)
        {
            ServiceResponseModel<ClientModelDTO> serviceResponse = new();

            ClientModel client = newClient.ToClientModel();

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            serviceResponse.Data = client.ToClientModelDTO();

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<string>> DeleteClient(Guid id)
        {
            ServiceResponseModel<String> serviceResponse = new();

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

        public async Task<ServiceResponseModel<List<ClientModelDTO>>> GetAll()
        {
            ServiceResponseModel<List<ClientModelDTO>> serviceResponse = new();

            try
            {
                var clients = await _context.Clients.Include("Notes").ToListAsync();
                if (clients is null)
                {
                    throw new Exception("Something went wrong.");
                }

                List<ClientModelDTO> clientsDTO = new();
                foreach (ClientModel client in clients)
                {
                    clientsDTO.Add(client.ToClientModelDTO());
                }

                serviceResponse.Data = clientsDTO;
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<ClientModelDTO>> GetOne(Guid id)
        {
            ServiceResponseModel<ClientModelDTO> serviceResponse = new();

            try
            {
                var clientFromDB = await _context.Clients.Include("Notes").FirstOrDefaultAsync(client => client.Id == id);
                if (clientFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                serviceResponse.Data = clientFromDB.ToClientModelDTO();
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<ClientModelDTO>> UpdateClient(Guid id, Request_ClientModel updatedClient)
        {
            ServiceResponseModel<ClientModelDTO> serviceResponse = new();    
                
            try
            {
                var clientFromDB = await _context.Clients.Include("Notes").FirstOrDefaultAsync(client => client.Id == id);
                if (clientFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                clientFromDB.FirstName = updatedClient.FirstName;
                clientFromDB.LastName = updatedClient.LastName;
                await _context.SaveChangesAsync();

                serviceResponse.Data = clientFromDB.ToClientModelDTO();
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