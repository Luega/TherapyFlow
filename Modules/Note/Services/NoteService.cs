using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Modules.Common.Models;

namespace therapyFlow.Modules.Note.Services
{
    public class NoteService : INoteService
    {
        private static List<NoteModel> FakeDB = new List<NoteModel> {
            new NoteModel{ Id = 0, Title = "Test", Text = "Text" },
            new NoteModel{ Id = 1, Title = "Test2", Text = "Text2" },
            new NoteModel{ Id = 2, Title = "Test3", Text = "Text3" }
        };
        public ServiceResponseModel<NoteModel> CreateNote(Request_NoteModel newNote)
        {
            ServiceResponseModel<NoteModel> serviceResponse = new ServiceResponseModel<NoteModel>();

            NoteModel note = new NoteModel { 
                Id = FakeDB.Max(n => n.Id) + 1,
                Title = newNote.Title,
                Text = newNote.Text,
             };
            FakeDB.Add(note);

            serviceResponse.Data = note;

            return serviceResponse;
        }

        public ServiceResponseModel<string> DeleteNote(int id)
        {
            ServiceResponseModel<string> serviceResponse = new ServiceResponseModel<string>();

            try
            {
                if (FakeDB.FirstOrDefault(n => n.Id == id) is null) 
                {
                    throw new Exception($"Id {id} not found.");
                }

                FakeDB.Remove(FakeDB.FirstOrDefault(n => n.Id == id)!);
                serviceResponse.Data = "Note deleted successfully";
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }


            return serviceResponse;
        }

        public ServiceResponseModel<List<NoteModel>> GetAll()
        {
            ServiceResponseModel<List<NoteModel>> serviceResponse = new ServiceResponseModel<List<NoteModel>>();
            serviceResponse.Data = FakeDB;
            
            return serviceResponse;
        }

        public ServiceResponseModel<NoteModel> GetOne(int id)
        {
            ServiceResponseModel<NoteModel> serviceResponse = new ServiceResponseModel<NoteModel>();
            
            try
            {
                if (FakeDB.FirstOrDefault(n => n.Id == id) is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                serviceResponse.Data = FakeDB.FirstOrDefault(n => n.Id == id);
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public ServiceResponseModel<NoteModel> UpdateNote(int id, Request_NoteModel updatedNote)
        {
            ServiceResponseModel<NoteModel> serviceResponse = new ServiceResponseModel<NoteModel>();
            
            try
            {
                if (FakeDB.FirstOrDefault(n => n.Id == id) is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                NoteModel ?oldNote = FakeDB.FirstOrDefault(n => n.Id == id);
                oldNote!.Title = updatedNote.Title;
                oldNote!.Text = updatedNote.Text;
                serviceResponse.Data = FakeDB.FirstOrDefault(n => n.Id == id);
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