using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therapyFlow.Modules.Notes
{
    public class NotesModel
    {
        public int Id { set; get; }
        public string title { set; get; } = "";
        public string text { set; get; } = "";
    }
}