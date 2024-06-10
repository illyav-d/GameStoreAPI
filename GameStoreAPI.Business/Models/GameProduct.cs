namespace GameStoreAPI.Business.Models
{
    public class GameProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public int MinimumAge { get; set; }
        public string ImageURL { get; set; }
        public double PriceInEuro { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }
        public int GenreID { get; set; }
        public int PlatformID { get; set; }
        public Genre Genre { get; set; }
        public Platform Platform { get; set; }
    }
}
