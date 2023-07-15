using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therapyFlow.Modules.Note.Services
{
    public class NoteService : INoteService
    {
        private static List<NoteModel> FakeDB = new List<NoteModel> {
            new NoteModel{ Id = 0, title = "Test", text = "Text" },
            new NoteModel{ Id = 1, title = "Test2", text = "Text2" },
            new NoteModel{ Id = 2, title = "Test3", text = "Text3" }
        };
        public NoteModel CreateNote(Request_NoteModel newNote)
        {
            NoteModel note = new NoteModel { 
                Id = FakeDB.Max(n => n.Id) + 1,
                title = newNote.title,
                text = newNote.text,
             };
            FakeDB.Add(note);

            return note;
        }

        public int? DeleteNote(int id)
        {
            if (FakeDB.FirstOrDefault(n => n.Id == id) is null) {
                return null;
            }
            
            FakeDB.Remove(FakeDB.FirstOrDefault(n => n.Id == id)!);

            return id;
        }

        public List<NoteModel> GetAll()
        {
            return FakeDB;
        }

        public NoteModel GetOne(int id)
        {
            return FakeDB.FirstOrDefault(n => n.Id == id);
        }

        public NoteModel UpdateNote(int id, Request_NoteModel updatedNote)
        {
            NoteModel ?oldNote = FakeDB.FirstOrDefault(n => n.Id == id);
            oldNote!.title = updatedNote.title;
            oldNote!.text = updatedNote.text;
            return FakeDB.FirstOrDefault(n => n.Id == id);
        }
    }
}