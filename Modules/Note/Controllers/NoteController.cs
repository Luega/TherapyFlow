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

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteModel>> GetOne(Guid id)
        {
            return Ok(await _noteService.GetOne(id));
        }

        [HttpPost]
        public async Task<ActionResult<NoteModel>> CreateNote(Request_NoteModel newNote)
        {
            return Ok(await _noteService.CreateNote(newNote));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NoteModel>> UpdateNote(Guid id, Request_NoteModel updatedNote)
        {
            return Ok(await _noteService.UpdateNote(id, updatedNote));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<NoteModel>> DeleteNote(Guid id)
        {
            return Ok(await _noteService.DeleteNote(id)!);
        }
    }
}