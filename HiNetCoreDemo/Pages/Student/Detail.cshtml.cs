using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HiNetCoreDemo.Pages.Student
{
    public class DetailModel : PageModel
    {
        private readonly HiNetCoreDemo.Data.HiNetCoreDbContext _context;
        public DetailModel(HiNetCoreDemo.Data.HiNetCoreDbContext context)
        {
            _context = context;
        }
        public HiNetCoreDemo.Models.Student Student { get; set; }
        public List<HiNetCoreDemo.Models.Subject> Subjects { get; set; }

        public void OnGet(int id)
        {
            Student = _context.Student.Include(x => x.Subjects).SingleOrDefault(x => x.Id == id);
        }
    }
}