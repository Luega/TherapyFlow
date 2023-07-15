using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therapyFlow.Modules.Note
{
    public class NoteModel
    {
        public int Id { set; get; }
        public string Title { set; get; } = "";
        public string Text { set; get; } = "";
    }
}