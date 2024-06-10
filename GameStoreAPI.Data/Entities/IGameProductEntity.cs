namespace GameStoreAPI.Data.Entities
{
    public interface IGameProductEntity : INameableEntity
    {
        bool Active { get; set; }
        string Description { get; set; }
        string Developer { get; set; }
        GenreEntity Genre { get; set; }
        int GenreID { get; set; }
        string ImageURL { get; set; }
        int MinimumAge { get; set; }
        PlatformEntity Platform { get; set; }
        int PlatformID { get; set; }
        double PriceInEuro { get; set; }
        string Publisher { get; set; }
        DateTime? ReleaseDate { get; set; }
        int Stock { get; set; }
    }
}