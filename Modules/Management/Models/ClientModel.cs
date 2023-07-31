using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Modules.Note;

namespace therapyFlow.Modules.Management.Models
{
    public class ClientModel
    {
        public Guid Id { set; get; }
        public string FirstName { set; get; } = "";
        public string LastName { set; get; } = "";
        public List<NoteModel> Notes { set; get; } = new List<NoteModel>();
    }
}