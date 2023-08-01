using therapyFlow.Modules.Note.Models;

namespace therapyFlow.Modules.Note.Mapper
{
    public static class NoteMapper
    {
        public static NoteModel ToNoteModel(this Request_NoteModel req)
        {
            return new NoteModel
            {
                Id = Guid.NewGuid(),
                Title = req.Title,
                Text = req.Text,
                ClientId = req.CustomerId,
            };
        }
        public static NoteModelDTO ToNoteModelDTO (this NoteModel note)
        {
            return new NoteModelDTO
            {
                Id = note.Id,
                Title = note.Title,
                Text = note.Text,
                CustomerId = note.ClientId
            };
        }
    }
}