using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SAP.Data.Data;
using SAP.Models;

namespace SAP.Web.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Subject> Subjects { get; set; }

        public async Task OnGetAsync()
        {
            Subjects = await _context.Subjects.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var auth = await _context.Subjects.FindAsync(id);

            if (auth != null)
            {
                _context.Subjects.Remove(auth);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
