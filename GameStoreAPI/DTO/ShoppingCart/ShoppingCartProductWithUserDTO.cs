namespace GameStoreAPI.DTO.ShoppingCart
{
    public class ShoppingCartProductWithUserDTO
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public string GameProductName { get; set; }
        public double GameProductPrice { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
