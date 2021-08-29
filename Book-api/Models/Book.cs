using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_api.Models
{
    public class Book
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string writer { get; set; }
        public string category { get; set; }
        public string publication { get; set; }
    }
}
