using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Pages.BikeRoutes
{
    public class CreateModel : PageModel
    {
        private readonly BloggieToBike.Web.Data.BloggieToBikeDbContext _bikeRouteContext;

        public CreateModel(Web.Data.BloggieToBikeDbContext bikeRouteContext)
        {
            _bikeRouteContext = bikeRouteContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BikeRoute BikeRoute { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _bikeRouteContext.BikeRoutes == null || BikeRoute == null)
            {
                return Page();
            }

            _bikeRouteContext.BikeRoutes.Add(BikeRoute);
            await _bikeRouteContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
