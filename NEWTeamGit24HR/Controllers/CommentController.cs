using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NEWTeamGit24HR.Controllers
{
    public class CommentController : ApiController
    {
        [Authorize]
        public class NoteController : ApiController
        {
            public IHttpActionResult Get()
            {
                CommentService noteService = CreateNoteService();
                var notes = noteService.GetNotes();
                return Ok(notes);
            }

            public IHttpActionResult Post(NoteCreate note)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateNoteService();

                if (!service.CreateNote(note))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult Get(int id)
            {
                CommentService commentService = CreateNoteService();
                var note = commentService.GetCommentById(id);
                return Ok(note);
            }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateNoteService();

                if (!service.DeleteNote(id))
                {
                    return InternalServerError();
                }

                return Ok();
            }

            private CommentService CreateNoteService()
            {
                Guid userId = Guid.Parse(User.Identity.GetUserId());
                var noteService = new CommentService(userId);
                return noteService;
            }
        }
    }
}
