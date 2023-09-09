using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Pages.BikeRoutes
{
    public class IndexModel : PageModel
    {
        private readonly BloggieToBike.Web.Data.BloggieToBikeDbContext _context;

        public IndexModel(BloggieToBike.Web.Data.BloggieToBikeDbContext context)
        {
            _context = context;
        }

        public IList<BikeRoute> BikeRoute { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Directions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BikeRouteDirection { get; set; }


        public async Task OnGetAsync()
        {
            //use LINQ to get a list of directions
            IQueryable<string> directionQuery = from d in _context.BikeRoutes
                                                orderby d.Direction
                                                select d.Direction;

            var bikeRoutes = from b in _context.BikeRoutes
                             select b;

            if (!string.IsNullOrEmpty(SearchString))
            {
                bikeRoutes = bikeRoutes.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BikeRouteDirection))
            {
                bikeRoutes = bikeRoutes.Where(d => d.Direction == BikeRouteDirection);
            }

            Directions = new SelectList(await directionQuery.Distinct().ToListAsync());
            BikeRoute = await bikeRoutes.ToListAsync();

            //if (_context.BikeRoute != null)
            //{
            //    BikeRoute = await _context.BikeRoute.ToListAsync();
            //}
        }
    }
}
