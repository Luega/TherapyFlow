using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therapyFlow.Modules.Note
{
    public interface INoteService
    {
         List<NoteModel> GetAll();
         NoteModel GetOne(int id);
         NoteModel CreateNote(Request_NoteModel newNote);
         NoteModel UpdateNote(int id, Request_NoteModel updatedNote);
         int? DeleteNote(int id);

    }
}