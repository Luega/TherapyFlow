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

        public async Task<ServiceResponseModel<ClientModel>> CreateClient(Request_ClientModel newClient)
        {
            ServiceResponseModel<ClientModel> serviceResponse = new ServiceResponseModel<ClientModel>();

            ClientModel client = newClient.ToClientModel();

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Clients.FindAsync(client.Id);

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<string>> DeleteClient(int id)
        {
            ServiceResponseModel<String> serviceResponse = new ServiceResponseModel<String>();

            try
            {
                var clientFromDB = await _context.Clients.FindAsync(id);
                if (clientFromDB is null) 
                {
                    throw new Exception($"Id {id} not found.");
                }

                var clientNotes = await _context.Notes.Where(note => note.ClientId == id).ToListAsync();
                if (!(clientNotes is null))
                {
                    _context.Notes.RemoveRange(clientNotes);
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
            serviceResponse.Data = await _context.Clients.Include("Notes").ToListAsync();
            
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