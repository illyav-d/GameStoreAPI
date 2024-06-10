namespace GameStoreAPI.DTO.ShoppingCart
{
    public class SimplifiedShoppingCartProductDTO
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public string GameProductName { get; set; }
        public double GameProductPrice { get; set; }
    }
}
