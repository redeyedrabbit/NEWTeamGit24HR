using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Models
{
    class CommentDetail
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
    }
}
