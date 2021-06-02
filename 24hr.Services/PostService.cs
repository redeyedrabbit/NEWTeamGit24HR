using _24hr.Data;
using _24hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Services
{
    public class PostService
    {
        private readonly Guid _authorId;

        public PostService(Guid authorId)
        {
            _authorId = authorId;
        }
        // Create Post
        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                AuthorId = _authorId,
                Title = model.Title,
                Text = model.Text
            };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // Get Posts by Id
        public IEnumerable<PostListItem> GetPots()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts.Single(e => e.PostId == id && e.AuthorId == _authorId);
                return new PostDetail
                {
                    PostId = entity.PostId,
                    Title = entity.Title,
                    Text = entity.Text
                };
            }
        }

        // Update Post
        public bool UpdatePost(PostUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.SIngle(e => e.PostId == model.PostId && e.AuthorId == _authorId);
                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Post
        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts
                    .Single(e => e.PostId == postId && e.AuthorId == _authorId);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
