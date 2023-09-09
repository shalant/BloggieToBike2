//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using BikeApp.Data;
//using BikeApp.Models;

//namespace BikeApp.Pages.BikeRoutes
//{
//    public class DeleteModel : PageModel
//    {
//        private readonly BikeApp.Data.ApplicationDbContext _context;

//        public DeleteModel(BikeApp.Data.ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//      public BikeRoute BikeRoute { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null || _context.BikeRoutes == null)
//            {
//                return NotFound();
//            }

//            var bikeroute = await _context.BikeRoutes.FirstOrDefaultAsync(m => m.Id == id);

//            if (bikeroute == null)
//            {
//                return NotFound();
//            }
//            else 
//            {
//                BikeRoute = bikeroute;
//            }
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync(int? id)
//        {
//            if (id == null || _context.BikeRoutes == null)
//            {
//                return NotFound();
//            }
//            var bikeroute = await _context.BikeRoutes.FindAsync(id);

//            if (bikeroute != null)
//            {
//                BikeRoute = bikeroute;
//                _context.BikeRoutes.Remove(BikeRoute);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToPage("./Index");
//        }
//    }
//}
