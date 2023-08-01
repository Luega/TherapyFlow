using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using therapyFlow.Modules.Common.Models;
using therapyFlow.Modules.Note.Models;

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
            ServiceResponseModel<NoteModelDTO> res = await _noteService.GetOne(id);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<NoteModel>> CreateNote(Request_NoteModel newNote)
        {
            ServiceResponseModel<NoteModelDTO> res = await _noteService.CreateNote(newNote);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NoteModel>> UpdateNote(Guid id, Request_NoteModel updatedNote)
        {
            ServiceResponseModel<NoteModelDTO> res = await _noteService.UpdateNote(id, updatedNote);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteNote(Guid id)
        {
            ServiceResponseModel<String> res = await _noteService.DeleteNote(id);
            if (res.Success == false)
            {
                return NotFound(res);
            }
            
            return Ok(res);
        }
    }
}