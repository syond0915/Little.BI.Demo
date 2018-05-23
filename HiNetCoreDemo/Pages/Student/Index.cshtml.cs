using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiNetCoreDemo.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HiNetCoreDemo.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly HiNetCoreDemo.Data.HiNetCoreDbContext _context;
        private readonly IDateTime _dateTime;

        public IndexModel(HiNetCoreDemo.Data.HiNetCoreDbContext context,IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }
        public PaginatedList<HiNetCoreDemo.Models.Student> Students { get; set; }
        public PaginatedList<HiNetCoreDemo.Models.Subject> Subjects { get; set; }

        [TempData]
        public string NameSortParm { get; set; }        
        [TempData]
        public string IdSortParm { get; set; }
        [TempData]
        public string CurrentSort { get; set; }
        [TempData]
        public string CurrentFilter { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder, string currentFilter, int currentPageIndex = 1, int pageSize = 3)
        {
            var serviceTime = _dateTime.Now;
            if (serviceTime.Hour < 12)
                TempData["Message"] = "It's morning here  -  Good Morning!";
           else if (serviceTime.Hour < 17)
                TempData["Message"] = "It's afternoon here  -  Good Afternoon!";
            else
                TempData["Message"] = "It's evening here  -  Good Evening!";

            TempData["CurrentSort"] = sortOrder;
            TempData["CurrentFilter"] = currentFilter;

            TempData["IdSortParm"] = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            TempData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";

            var students = from m in _context.Student.Include(m => m.Subjects)
                           select m;
            if (!string.IsNullOrEmpty(currentFilter))
            {
                students = students.Where(m => m.StId.Contains(currentFilter) || m.StName.Contains(currentFilter));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(x => x.StName);
                    break;
                case "Name":
                    students = students.OrderBy(x => x.StName);
                    break;
                case "id_desc":
                    students = students.OrderByDescending(x => x.StId);
                    break;
                default:
                    students = students.OrderBy(x => x.StId);
                    break;
            }
            //Students = await students.ToListAsync();
            Students = await PaginatedList<Models.Student>.CreatePagingAsync(students.AsNoTracking(), currentPageIndex, pageSize);            
            return Page();
        }
        public async Task<IActionResult> OnPostFilterAsync(string sortOrder, string searchString, int currentPageIndex = 1, int pageSize = 3)
        {
            TempData["CurrentSort"] = sortOrder;
            TempData["CurrentFilter"] = searchString;

            TempData["IdSortParm"] = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            TempData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";

            
            var students = from m in _context.Student.Include(x => x.Subjects).OrderBy(x => x.StId)
                           select m;
            
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(m => m.StId.Contains(searchString) || m.StName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(x => x.StName);
                    break;
                case "Name":
                    students = students.OrderBy(x => x.StName);
                    break;
                case "id_desc":
                    students = students.OrderByDescending(x => x.StId);
                    break;
                default:
                    students = students.OrderBy(x => x.StId);
                    break;
            }
            //Students = await students.ToListAsync();
            Students = await PaginatedList<Models.Student>.CreatePagingAsync(students.AsNoTracking(), currentPageIndex, pageSize);
            return Page();
        }

    }
}