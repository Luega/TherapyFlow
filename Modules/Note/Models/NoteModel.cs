using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therapyFlow.Modules.Management.Models;

namespace therapyFlow.Modules.Note
{
    public class NoteModel
    {
        public Guid Id { set; get; }
        public string Title { set; get; } = "";
        public string Text { set; get; } = "";
        public Guid ClientId { get; set; }
        public ClientModel Client { get; set; } = null!;
    }
}