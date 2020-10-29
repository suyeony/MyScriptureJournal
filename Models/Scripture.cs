using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }
        public string Chapter { get; set; }
        public string Notes { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }        
        public Book book { get; set; }


    }

}