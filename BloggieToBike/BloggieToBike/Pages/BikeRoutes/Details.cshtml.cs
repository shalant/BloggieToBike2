using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloggieToBike.Web.Data;
using BloggieToBike.Web.Models;
using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Pages.BikeRoutes
{
    public class DetailsModel : PageModel
    {
        private readonly BloggieToBike.Web.Data.BloggieToBikeDbContext _context;

        public DetailsModel(BloggieToBike.Web.Data.BloggieToBikeDbContext context)
        {
            _context = context;
        }

        public BikeRoute BikeRoute { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BikeRoutes == null)
            {
                return NotFound();
            }

            var bikeroute = await _context.BikeRoutes.FirstOrDefaultAsync(m => m.Id == id);
            if (bikeroute == null)
            {
                return NotFound();
            }
            else
            {
                BikeRoute = bikeroute;
            }
            return Page();
        }
    }
}
