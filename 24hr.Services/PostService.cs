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
        // Get Posts
        public IEnumerable<PostListItem> GetPots()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Posts
            }
        }
    }
}
