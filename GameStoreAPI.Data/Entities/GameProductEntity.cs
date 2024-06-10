using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.Data.Entities
{
    public class GameProductEntity : IGameProductEntity
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }

        [MaxLength(100)]
        public string Developer { get; set; }

        [MaxLength(100)]
        public string Publisher { get; set; }
        public int MinimumAge { get; set; }

        [MaxLength(100)]
        public string? ImageURL { get; set; }
        public double PriceInEuro { get; set; }

        [Range(0, 20)]
        public int Stock { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Active { get; set; }

        //Navigationproperties
        public int GenreID { get; set; }
        public int PlatformID { get; set; }
        public GenreEntity Genre { get; set; }
        public PlatformEntity Platform { get; set; }
        public List<ShoppingCartProductEntity> ShoppingCartProducts { get; set;}
    }
}
