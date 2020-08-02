using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_manager.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearEdition { get; set; }
        public decimal Value { get; set; }

         /* Entity Framework class association,
         he knows that GenderId is a foreign key
         in Book class. */
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
    }
}