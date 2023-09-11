using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloggieToBike.Web.Data;
using BloggieToBike.Web.Models;
using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Pages.BikeRoutes
{
    public class EditModel : PageModel
    {
        private readonly BloggieToBike.Web.Data.BloggieToBikeDbContext _context;

        public EditModel(BloggieToBike.Web.Data.BloggieToBikeDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BikeRoute BikeRoute { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid guid)
        {
            if (guid == null || _context.BikeRoutes == null)
            {
                return NotFound();
            }

            var bikeroute = await _context.BikeRoutes.FirstOrDefaultAsync(m => m.Id == guid);
            if (bikeroute == null)
            {
                return NotFound();
            }
            BikeRoute = bikeroute;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BikeRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
                //if (!BikeRouteExists(BikeRoute))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return RedirectToPage("./Index");
        }

        private bool BikeRouteExists(Guid id)
        {
            return (_context.BikeRoutes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
