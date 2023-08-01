using therapyFlow.Data;
using therapyFlow.Modules.Common.Models;
using therapyFlow.Modules.Note.Mapper;
using therapyFlow.Modules.Note.Models;

namespace therapyFlow.Modules.Note.Services
{
    public class NoteService : INoteService
    {
        private readonly DataContext _context;

        public NoteService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponseModel<NoteModelDTO>> CreateNote(Request_NoteModel newNote)
        {
            ServiceResponseModel<NoteModelDTO> serviceResponse = new();

            try
            {
                var customer = await _context.Customers.FindAsync(newNote.CustomerId);
                if (customer is null)
                {
                    throw new Exception($"CustomerId {newNote.CustomerId} not found.");
                }

                NoteModel note = newNote.ToNoteModel();

                Console.WriteLine(note);

                _context.Notes.Add(note);
                await _context.SaveChangesAsync();

                serviceResponse.Data = note.ToNoteModelDTO();

            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<string>> DeleteNote(Guid id)
        {
            ServiceResponseModel<String> serviceResponse = new();

            try
            {
                var noteFromDB = await _context.Notes.FindAsync(id);
                if (noteFromDB is null) 
                {
                    throw new Exception($"Id {id} not found.");
                }

                _context.Notes.Remove(noteFromDB);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            serviceResponse.Data = "Note deleted successfully";

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<NoteModelDTO>> GetOne(Guid id)
        {
            ServiceResponseModel<NoteModelDTO> serviceResponse = new();
            
            try
            {
                var noteFromDB = await _context.Notes.FindAsync(id);
                if (noteFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                serviceResponse.Data = noteFromDB.ToNoteModelDTO();
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public  async Task<ServiceResponseModel<NoteModelDTO>> UpdateNote(Guid id, Request_NoteModel updatedNote)
        {
            ServiceResponseModel<NoteModelDTO> serviceResponse = new();
            
            try
            {
                var client = await _context.Customers.FindAsync(updatedNote.CustomerId);
                if (client is null)
                {
                    throw new Exception($"ClientId {updatedNote.CustomerId} not found.");
                }

                var noteFromDB = await _context.Notes.FindAsync(id);
                if (noteFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                noteFromDB.Title = updatedNote.Title;
                noteFromDB.Text = updatedNote.Text;
                noteFromDB.CustomerId = updatedNote.CustomerId;
                await _context.SaveChangesAsync();

                serviceResponse.Data = noteFromDB.ToNoteModelDTO();
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