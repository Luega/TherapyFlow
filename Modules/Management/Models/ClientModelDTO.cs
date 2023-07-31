using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Modules.Note;
using therapyFlow.Modules.Note.Models;

namespace therapyFlow.Modules.Management.Models
{
    public class ClientModelDTO
    {
        public Guid Id { set; get; }
        public string FirstName { set; get; } = "";
        public string LastName { set; get; } = "";
        public List<NoteModelDTO> Notes { set; get; } = new();
    }
}