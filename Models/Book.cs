using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Book
    {
        [Display(Name = "Book")]
        public int BookId { get; set; }

        [Display(Name = "Book Name")]
        public string BookName { get; set; }

    }

}
