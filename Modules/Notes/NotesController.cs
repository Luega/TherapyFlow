using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace therapyFlow.Modules.Notes
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private static List<NotesModel> FakeDB = new List<NotesModel> {
            new NotesModel{ Id = 0, title = "Test", text = "Text" },
            new NotesModel{ Id = 1, title = "Test2", text = "Text2" },
            new NotesModel{ Id = 2, title = "Test3", text = "Text3" }
        };

        [HttpGet]
        public ActionResult<List<NotesModel>> Get()
        {
            return Ok(FakeDB);
        }

        [HttpGet("{id}")]
        public ActionResult<NotesModel> GetOne(int id)
        {
            return Ok(FakeDB.FirstOrDefault(n => n.Id == id));
        }
    }
}