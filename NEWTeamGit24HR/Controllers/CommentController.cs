using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NEWTeamGit24HR.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        
            public IHttpActionResult Get()
            {
                CommentService noteService = CreateCommentService();
                var notes = noteService.GetComments();
                return Ok(notes);
            }

            public IHttpActionResult Post(CommentCreate comment)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateCommentService();

                if (!service.CreateComment(comment))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult Get(int id)
            {
                CommentService commentService = CreateCommentService();
                var comment = commentService.GetCommentById(id);
                return Ok(comment);
            }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateCommentService();

                if (!service.DeleteComment(id))
                {
                    return InternalServerError();
                }

                return Ok();
            }

            private CommentService CreateCommentService()
            {
                Guid userId = Guid.Parse(User.Identity.GetUserId());
                var commentService = new CommentService(userId);
                return commentService;
            }
        }
    }
}
