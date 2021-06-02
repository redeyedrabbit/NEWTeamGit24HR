using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Data
{
    public class Comment
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(500, ErrorMessage = "You entered too many characters. Please reduce length of comment.")]
        public string Text { get; set; }
        [Required]
        public Guid AuthorId { get; set; } // Basic comment set up.
               
        [ForeignKey(nameof(Reply))]
        public int ReplyId { get; set; }
        public virtual Reply Reply { get; set; }

        


    }
}



