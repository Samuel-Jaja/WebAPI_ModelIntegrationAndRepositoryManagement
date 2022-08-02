
using CCSA_Web.DTO_s;
using CCSANoteApp.Domain;
using CCSANoteApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CCSA_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        public INoteService NoteService { get; }
        public NoteController(INoteService noteService)
        {
            NoteService = noteService;
        }
        [HttpPost("create-note")]
        public IActionResult CreateNote([FromBody] NoteDto note)
        {
            NoteService.CreateNote(note.creatorUserId, note.Title, note.Content, note.GroupName);
            return Ok("Created Successfully");
        }

        //[HttpPost]
        //public IActionResult CreateNote(Guid userId, string title, string content, string groupName)
        //{
        //    NoteService.CreateNote(userId, title, content, groupName);
        //    return Ok("Created Successfully");
        //}
        [HttpDelete]
        public IActionResult DeleteNote(Guid id)
        {
            NoteService.DeleteNote(id);
            return Ok("Deleted Successfully");
        }

        [HttpDelete("multiple")]
        public IActionResult DeleteNote([FromBody]List<Guid> noteIds)
        {
            NoteService.DeleteNote(noteIds);
            return Ok("Deleted Successfully");
        }
        [HttpGet("note")]
        public IActionResult FetchNote()
        {
            return Ok(NoteService.FetchNote());
        }
        [HttpGet("notegroup")]
        public IActionResult FetchNoteByGroup(Guid userId, string groupName)
        {
            return Ok(NoteService.FetchNoteByGroup(userId,groupName));
        }

        [HttpGet("byId/{id}")]
        public IActionResult FetchNoteById(Guid id)
        {
            return Ok(NoteService.FetchNoteById(id));
        }

        [HttpGet("byUser/{id}")]
        public IActionResult FetchNoteByUser(Guid id)
        {
            return Ok(NoteService.FetchNoteByUser(id));
        }
        [HttpPut]
        public IActionResult UpdateNote(Guid id, [FromBody] NoteDto note)
        {
            NoteService.UpdateNote(id, note.Content);
            return Ok("Updated Successfully");
        }

        [HttpPut("updatecontent")]
        public IActionResult UpdateNote(Guid id, string content)
        {
            NoteService.UpdateNote(id, content);
            return Ok("Updated Successfully");
        }

        [HttpPut("updatetitle")]
        public IActionResult UpdateNoteTitle(Guid id, string title)
        {
            NoteService.UpdateNoteTitle(id, title);
            return Ok("Updated Successfully");
        }
    }
}
