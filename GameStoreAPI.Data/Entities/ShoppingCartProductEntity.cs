using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.Data.Entities
{
    public class ShoppingCartProductEntity : IEntity
    {
        public int ID { get ; set; }

        public int UserID { get; set; }
        public UserEntity User { get; set; }
        public int GameProductID { get; set; }
        public GameProductEntity GameProduct { get; set; }

        [Range(0, 20)]
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
