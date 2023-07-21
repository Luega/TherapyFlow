using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using therapyFlow.Data;
using therapyFlow.Modules.Common.Models;

namespace therapyFlow.Modules.Note.Services
{
    public class NoteService : INoteService
    {
        private readonly DataContext _context;

        public NoteService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponseModel<NoteModel>> CreateNote(Request_NoteModel newNote)
        {
            ServiceResponseModel<NoteModel> serviceResponse = new ServiceResponseModel<NoteModel>();

            try
            {
                var client = await _context.Clients.FindAsync(newNote.ClientId);
                if (client is null)
                {
                    throw new Exception($"ClientId {newNote.ClientId} not found.");
                }

                var lastId = await _context.Notes.OrderByDescending(note => note.Id).FirstOrDefaultAsync();
                int nextId = 1;
                if (lastId != null)
                {
                    nextId = lastId.Id + 1;
                }

                NoteModel note = new NoteModel
                {
                    Id = nextId,
                    Title = newNote.Title,
                    Text = newNote.Text,
                    ClientId = newNote.ClientId,
                };
                
                _context.Notes.Add(note);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Notes.FindAsync(nextId);

            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<string>> DeleteNote(int id)
        {
            ServiceResponseModel<String> serviceResponse = new ServiceResponseModel<String>();

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

        public async Task<ServiceResponseModel<List<NoteModel>>> GetAll()
        {
            ServiceResponseModel<List<NoteModel>> serviceResponse = new ServiceResponseModel<List<NoteModel>>();
            serviceResponse.Data = await _context.Notes.ToListAsync();
            
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<NoteModel>> GetOne(int id)
        {
            ServiceResponseModel<NoteModel> serviceResponse = new ServiceResponseModel<NoteModel>();
            
            try
            {
                var noteFromDB = await _context.Notes.FindAsync(id);
                if (noteFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                serviceResponse.Data = noteFromDB;
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public  async Task<ServiceResponseModel<NoteModel>> UpdateNote(int id, Request_NoteModel updatedNote)
        {
            ServiceResponseModel<NoteModel> serviceResponse = new ServiceResponseModel<NoteModel>();
            
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

                serviceResponse.Data = await _context.Notes.FindAsync(id);
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