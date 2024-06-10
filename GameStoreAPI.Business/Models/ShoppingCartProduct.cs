namespace GameStoreAPI.Business.Models
{
    public class ShoppingCartProduct
    {
        public int ID { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
        public int GameProductID { get; set; }
        public GameProduct GameProduct { get; set; }

        public int Amount { get; set; }
        public double TotalPrice { get { return Amount * GameProduct.PriceInEuro; } }

        //TODO: Moeten wij hier nog iets doen?
    }
}
