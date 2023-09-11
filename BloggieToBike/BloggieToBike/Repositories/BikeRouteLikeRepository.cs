using BloggieToBike.Web.Data;
using BloggieToBike.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloggieToBike.Web.Repositories
{
    public class BikeRouteLikeRepository : IBikeRouteLikeRepository
    {
        private readonly BloggieToBikeDbContext bloggieToBikeDbContext;

        public BikeRouteLikeRepository(BloggieToBikeDbContext bloggieToBikeDbContext)
        {
            this.bloggieToBikeDbContext = bloggieToBikeDbContext;
        }

        //public async Task AddLikeForBikeRoute(Guid bikeRouteId, Guid userId)
        public async Task AddLikeForBikeRoute(int bikeRouteId, int userId)
        {
            var like = new BikeRouteLike
            {
                //Id = Guid.NewGuid(),
                BikeRouteId = bikeRouteId,
                UserId = userId,
            };

            await bloggieToBikeDbContext.BikeRouteLikes.AddAsync(like);
            await bloggieToBikeDbContext.SaveChangesAsync();
        }

        //public async Task<IEnumerable<BikeRouteLike>> GetLikesForBikeRoute(Guid bikeRouteId)
        public async Task<IEnumerable<BikeRouteLike>> GetLikesForBikeRoute(int bikeRouteId)
        {
            return await bloggieToBikeDbContext.BikeRouteLikes.Where(x => x.BikeRouteId == bikeRouteId)
                .ToListAsync();
        }

        //public async Task<int> GetTotalLikesForBikeRoute(Guid bikeRouteId)
        public async Task<int> GetTotalLikesForBikeRoute(int bikeRouteId)
        {
            return await bloggieToBikeDbContext.BikeRouteLikes
                .CountAsync(x => x.BikeRouteId == bikeRouteId);
        }
    }
}
