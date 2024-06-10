using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.Data.Entities
{
    public class UserEntity : IEntity
    {
        public int ID { get;  set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        //Navigationproperty
        public List<ShoppingCartProductEntity> ShoppingCartProducts { get; set; }
    }
}
