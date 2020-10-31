using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public string BookSort { get; set; }
        public string DateSort { get; set; }

        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public IList<Scripture> Scripture { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Scripture> scripturesIQ = from s in _context.Scripture
                                        select s;

             if (!String.IsNullOrEmpty(searchString))
            {
            scripturesIQ = scripturesIQ.Where(s => s.book.BookName.Contains(searchString)
                                   || s.Notes.Contains(searchString));
            }

             switch (sortOrder)
            {
            case "book_desc":
                scripturesIQ = scripturesIQ.OrderByDescending(s => s.book.BookName);
                break;
            case "Date":
                scripturesIQ = scripturesIQ.OrderBy(s => s.CreateDate);
                break;
            case "date_desc":
                scripturesIQ = scripturesIQ.OrderByDescending(s => s.CreateDate);
                break;
            default:
                scripturesIQ = scripturesIQ.OrderBy(s => s.book.BookName);
                break;
            }

            Scripture = await scripturesIQ.AsNoTracking()
                .Include(s => s.book).ToListAsync();
        }
    }
}
