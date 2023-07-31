using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Modules.Management.Models;

namespace therapyFlow.Modules.Management.Mappers
{
    public static class ClientMapper
    {
        public static ClientModel ToClientModel(this Request_ClientModel req)
        {
            return new ClientModel
            {
                Id = Guid.NewGuid(),
                FirstName = req.FirstName,
                LastName = req.LastName,
            };
        }
    }
}