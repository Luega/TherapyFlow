using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Modules.Management.Models;
using therapyFlow.Modules.Note;
using therapyFlow.Modules.Note.Mapper;
using therapyFlow.Modules.Note.Models;

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
        public static ClientModelDTO ToClientModelDTO(this ClientModel client)
        {
            return new ClientModelDTO
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Notes = NoteMapperHelper(client.Notes),
            };
        }
        private static List<NoteModelDTO> NoteMapperHelper(this List<NoteModel> clientNotes)
        {
            List<NoteModelDTO> clientNotesDTO = new();
            foreach (NoteModel note in clientNotes)
            {
                clientNotesDTO.Add(note.ToNoteModelDTO());
            }

            return clientNotesDTO;
        }
    }
}