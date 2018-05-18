using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HiNetCoreDemo.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly HiNetCoreDemo.Data.HiNetCoreDbContext _context;

        public CreateModel(HiNetCoreDemo.Data.HiNetCoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HiNetCoreDemo.Models.Student Student { get; set; }

        [BindProperty]
        public List<HiNetCoreDemo.Models.Subject> Subjects { get; set; }

        public void OnGet()
        {
            Student = new Models.Student()
            {
                Subjects = new List<Models.Subject>
                {
                    new Models.Subject()
                }
            };
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _context.Student.Add(Student);
            _context.Subject.AddRange(Subjects);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        public IActionResult OnPostSubjectAsync()
        {
            Student.Subjects.Add(new Models.Subject());
            return Page();
        }
    }
}