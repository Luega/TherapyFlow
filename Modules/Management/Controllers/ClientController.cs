using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using therapyFlow.Modules.Management.Models;
using therapyFlow.Modules.Management.Services;

namespace therapyFlow.Modules.Management.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientModel>>> GetAll()
        {
            return Ok(await _clientService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetOne(Guid id)
        {
            return Ok(await _clientService.GetOne(id));
        }

        [HttpPost]
        public async Task<ActionResult<ClientModel>> CreateClient(Request_ClientModel newClient)
        {
            return Ok(await _clientService.CreateClient(newClient));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientModel>> UpdateClient(Guid id, Request_ClientModel updatedClient)
        {
            return Ok(await _clientService.UpdateClient(id, updatedClient));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientModel>> DeleteClient(Guid id)
        {
            return Ok(await _clientService.DeleteClient(id)!);
        }
    }
}