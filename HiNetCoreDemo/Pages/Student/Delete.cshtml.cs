using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HiNetCoreDemo.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private readonly HiNetCoreDemo.Data.HiNetCoreDbContext _context;

        public DeleteModel(HiNetCoreDemo.Data.HiNetCoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HiNetCoreDemo.Models.Student Student { get; set; }

        public void OnGet(int id)
        {
            Student = _context.Student.Include(m=>m.Subjects).SingleOrDefault(m => m.Id == id);
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var model = _context.Student.Include(m => m.Subjects).SingleOrDefault(m => m.Id == id);
            if(model==null)
                return NotFound();

            _context.Student.Remove(model);
            _context.Subject.RemoveRange(model.Subjects);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}