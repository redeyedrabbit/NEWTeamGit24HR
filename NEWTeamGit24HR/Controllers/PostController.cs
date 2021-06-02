using _24hr.Models;
using _24hr.Services;
using Microsoft.AspNet.Identity;
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
        // Create Post Service
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }

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
            var posts = postService.GetPosts();
            return Ok(posts);
        }
        
        // Get Posts By AuthorId
        public IHttpActionResult Get(int id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostByAuthorId(id);
            return Ok(post);
        }

        // PUT (Update) a Post
        public IHttpActionResult Put(PostUpdate post)
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
