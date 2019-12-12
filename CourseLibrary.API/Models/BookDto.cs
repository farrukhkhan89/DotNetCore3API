using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    public class BookDto
    {
        public string BookId { get; set; }
        public string NameOfBook { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string AuthorName { get; set; }
    }
}
