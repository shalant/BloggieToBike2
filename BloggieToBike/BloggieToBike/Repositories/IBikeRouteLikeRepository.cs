using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Web.Repositories
{
    public interface IBikeRouteLikeRepository
    {
        //Task<int> GetTotalLikesForBikeRoute(Guid blogId);
        Task<int> GetTotalLikesForBikeRoute(int blogId);

        //Task AddLikeForBikeRoute(Guid blogPostId, Guid userId);
        Task AddLikeForBikeRoute(Guid blogPostId, int userId);

        //Task<IEnumerable<BikeRouteLike>> GetLikesForBikeRoute(Guid bikeRouteId);
        Task<IEnumerable<BikeRouteLike>> GetLikesForBikeRoute(int bikeRouteId);
    }
}
