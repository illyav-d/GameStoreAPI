using GameStoreAPI.DTO.ShoppingCart;

namespace GameStoreAPI.DTO.User
{
    public class DetailedUserDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public double TotalPriceOfCart { get; set; }
        public List<SimplifiedShoppingCartProductDTO> ShoppingCartProducts { get; set; } = new List<SimplifiedShoppingCartProductDTO>();
    }
}
