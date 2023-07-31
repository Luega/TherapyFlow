using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                var client = await _context.Clients.FindAsync(newNote.ClientId);
                if (client is null)
                {
                    throw new Exception($"ClientId {newNote.ClientId} not found.");
                }

                NoteModel note = newNote.ToNoteModel();

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
                var client = await _context.Clients.FindAsync(updatedNote.ClientId);
                if (client is null)
                {
                    throw new Exception($"ClientId {updatedNote.ClientId} not found.");
                }

                var noteFromDB = await _context.Notes.FindAsync(id);
                if (noteFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                noteFromDB.Title = updatedNote.Title;
                noteFromDB.Text = updatedNote.Text;
                noteFromDB.ClientId = updatedNote.ClientId;
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