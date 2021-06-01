using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }

        [Required]
        public int CommentId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Comment Comment { get; set; }
    }
}
