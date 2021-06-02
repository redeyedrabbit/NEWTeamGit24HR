using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Models
{
    public class PostCreate
    {
        // Rachel
        [Required]
        [MinLength(2, ErrorMessage = "Please enter atleast 2 characters")]
        [MaxLength(100, ErrorMessage ="You entered too many characters in this field")]
        public string Title { get; set; }

        [Required]
        [MinLength(100, ErrorMessage ="This post ins't long enough")]
        [MaxLength(8000, ErrorMessage ="This is too long...")]
        public string Text { get; set; }
    }
}
