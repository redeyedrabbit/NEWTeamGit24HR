using _24hr.Data;
using _24hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Services

{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(Comment model)
        {
            var entity =
                new Comment()
                {
                    Text = model.Text,
                    Id = model.Id,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Posts
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            Id = e.Id,
                            Text = e.Text
                        }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateComment(Comment comment)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.Id == comment.Id);

                entity.CommentId = comment.Id;
                entity.Text = comment.Text;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.Id == commentId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}


