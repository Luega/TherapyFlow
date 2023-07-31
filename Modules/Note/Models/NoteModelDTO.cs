using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therapyFlow.Modules.Note.Models
{
    public class NoteModelDTO
    {
        public Guid Id { set; get; }
        public string Title { set; get; } = "";
        public string Text { set; get; } = "";
        public Guid ClientId { get; set; }
    }
}