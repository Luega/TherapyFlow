using therapyFlow.Modules.Common.Models;
using therapyFlow.Modules.Note.Models;

namespace therapyFlow.Modules.Note
{
    public interface INoteService
    {
        Task<ServiceResponseModel<NoteModelDTO>> GetOne(Guid id);
        Task<ServiceResponseModel<NoteModelDTO>> CreateNote(Request_NoteModel newNote);
        Task<ServiceResponseModel<NoteModelDTO>> UpdateNote(Guid id, Request_NoteModel updatedNote);
        Task<ServiceResponseModel<string>> DeleteNote(Guid id);

    }
}