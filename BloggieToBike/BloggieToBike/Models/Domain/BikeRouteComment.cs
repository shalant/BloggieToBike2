namespace BloggieToBike.Web.Models.Domain
{
    public class BikeRouteComment
    {
        //public Guid Id { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        //public Guid BikeRouteId { get; set; }
        public int BikeRouteId { get; set; }
        //public Guid UserId { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
