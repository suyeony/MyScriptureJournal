using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        // Canonid
        public int ID { get; set; }

        [Display(Name = "Book")]
        public int BookId { get; set; }
  
        public string Chapter { get; set; }

        public string Verses { get; set; }
        public string Notes { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }        

        // Navigation 
        public Book book { get; set; }


    }

}