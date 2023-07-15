using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therapyFlow.Modules.Note
{
    public class Request_NoteModel
    {
        public string title { set; get; } = "";
        public string text { set; get; } = "";
    }
}