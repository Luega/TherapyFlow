using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace therapyFlow.Modules.Note
{
    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public ActionResult<List<NoteModel>> Get()
        {
            return Ok(_noteService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<NoteModel> GetOne(int id)
        {
            return Ok(_noteService.GetOne(id));
        }

        [HttpPost]
        public ActionResult<NoteModel> CreateNote(Request_NoteModel newNote)
        {
            return Ok(_noteService.CreateNote(newNote));
        }

        [HttpPut]
        public ActionResult<NoteModel> UpdateNote(int id, Request_NoteModel updatedNote)
        {
            return Ok(_noteService.UpdateNote(id, updatedNote));
        }

        [HttpDelete]
        public ActionResult<NoteModel> DeleteNote(int id)
        {
            return Ok(_noteService.DeleteNote(id));
        }
    }
}