using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_api.Models
{
    public class Book
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage ="Length size exceeded!")]
        public string title { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Length size exceeded!")]
        public string writer { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Length size exceeded!")]
        public string category { get; set; }
        
        [Required]
        [MaxLength(100,ErrorMessage ="Length size exceeded!")]
        public string publication { get; set; }
    }
}
