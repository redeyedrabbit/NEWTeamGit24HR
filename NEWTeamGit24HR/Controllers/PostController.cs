using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NEWTeamGit24HR.Controllers
{
    public class PostController : ApiController
    {
        // Create Post
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();
            return Ok();
        }

        // Get All Posts
        public  IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var note = postService.GetPosts();
            return Ok(posts);
        }

        // Get Posts By AuthorId
        public IHttpActionResult Get(int authorId)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostByAuthorId(authorId);
            return Ok(post);
        }

        // PUT (Update) a Post
        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }

        // Delete a Post
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();
            if (!service.DeletePost(id))
                return InternalServerError();
            return Ok();
        }
    }
}
