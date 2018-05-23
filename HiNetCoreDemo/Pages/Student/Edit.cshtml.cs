using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HiNetCoreDemo.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly HiNetCoreDemo.Data.HiNetCoreDbContext _context;

        public EditModel(HiNetCoreDemo.Data.HiNetCoreDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public HiNetCoreDemo.Models.Student Student { get; set; }
        public HiNetCoreDemo.Models.Subject Subject { get; set; }

        public void OnGet(int id)
        {
            Student = _context.Student.Include(m=>m.Subjects).SingleOrDefault(m => m.Id == id);
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //_context.Attach(Student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //foreach(var sub in Student.Subjects)
            //{
            //    _context.Attach(sub).State = EntityState.Modified;
            //}

            _context.Student.Update(Student);
            _context.Subject.UpdateRange(Student.Subjects);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}