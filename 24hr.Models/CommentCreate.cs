using _24hr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Models
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(3000)]
        public string Text { get; set; }
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int CommentId { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; } 
        public virtual Post Post { get; set; }
    }
}
