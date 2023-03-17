using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SAP.Data.Data;
using SAP.Models;

namespace SAP.Web.Pages.Subjects
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Subject Subjects { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Subjects.Name = Subjects.Name.Trim();
            Subjects.Id = Subjects.Id;
            Subjects.CreationDate = DateTime.Now;

            _context.Subjects.Add(Subjects);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
