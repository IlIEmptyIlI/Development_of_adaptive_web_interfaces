using Microsoft.AspNetCore.Mvc;
using NoteApp.Services;
using Laba9.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laba9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            var notes = await _noteService.GetNotes();
            return Ok(notes);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote([FromBody] Note note)
        {
            var createdNote = await _noteService.CreateNote(note);
            return Ok(createdNote);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Note>> UpdateNote(int id, [FromBody] Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            var updatedNote = await _noteService.UpdateNote(note);
            if (updatedNote == null)
            {
                return NotFound();
            }

            return Ok(updatedNote);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteNote(int id)
        {
            var result = await _noteService.DeleteNote(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok(true);
        }
    }
}
