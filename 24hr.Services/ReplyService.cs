using _24hr.Data;
using _24hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Services
{
    public class ReplyService
    {
        private readonly Guid _authorId;

        public ReplyService(Guid authorId)
        {
            _authorId = authorId;
        }


        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = _authorId,
                    Text = model.Text
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            ReplyId = e.Id,
                            Text = e.Text
                        }
                        );

                return query.ToArray();
            }
        }
    }
}
