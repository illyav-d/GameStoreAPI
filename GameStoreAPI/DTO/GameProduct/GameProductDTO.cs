namespace GameStoreAPI.DTO.GameProduct
{
    public class GameProductDTO
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
        public string GenreName { get; set; }
        public string PlatformName { get; set; }
    }
}
