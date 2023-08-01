using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using therapyFlow.Modules.Common.Models;
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
        public async Task<ActionResult<List<ClientModelDTO>>> GetAll()
        {
            ServiceResponseModel<List<ClientModelDTO>> res = await _clientService.GetAll();
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModelDTO>> GetOne(Guid id)
        {
            ServiceResponseModel<ClientModelDTO> res = await _clientService.GetOne(id);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<ClientModelDTO>> CreateClient(Request_ClientModel newClient)
        {
            ServiceResponseModel<ClientModelDTO> res = await _clientService.CreateClient(newClient);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientModelDTO>> UpdateClient(Guid id, Request_ClientModel updatedClient)
        {
            ServiceResponseModel<ClientModelDTO> res = await _clientService.UpdateClient(id, updatedClient);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteClient(Guid id)
        {
            ServiceResponseModel<String> res = await _clientService.DeleteClient(id);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }
    }
}