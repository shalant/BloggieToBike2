using BloggieToBike.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloggieToBike.Web.Data
{
    public class BloggieToBikeDbContext : DbContext
    {
        public BloggieToBikeDbContext(DbContextOptions<BloggieToBikeDbContext> options) : base(options)
        {
        }

        public DbSet<BikeRoute> BikeRoutes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BikeRouteLike> BikeRouteLikes { get; set; }
        public DbSet<BikeRouteComment> BikeRouteComments { get; set; }
    }
}
