using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Modules.Common.Models;

namespace therapyFlow.Modules.Note
{
    public interface INoteService
    {
         ServiceResponseModel<List<NoteModel>> GetAll();
         ServiceResponseModel<NoteModel> GetOne(int id);
         ServiceResponseModel<NoteModel> CreateNote(Request_NoteModel newNote);
         ServiceResponseModel<NoteModel> UpdateNote(int id, Request_NoteModel updatedNote);
         ServiceResponseModel<string>? DeleteNote(int id);

    }
}