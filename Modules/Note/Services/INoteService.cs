using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Modules.Common.Models;

namespace therapyFlow.Modules.Note
{
    public interface INoteService
    {
        Task<ServiceResponseModel<List<NoteModel>>> GetAll();
        Task<ServiceResponseModel<NoteModel>> GetOne(int id);
        Task<ServiceResponseModel<NoteModel>> CreateNote(Request_NoteModel newNote);
        Task<ServiceResponseModel<NoteModel>> UpdateNote(int id, Request_NoteModel updatedNote);
        Task<ServiceResponseModel<string>>? DeleteNote(int id);

    }
}