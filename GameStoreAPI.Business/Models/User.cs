namespace GameStoreAPI.Business.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public double TotalPriceOfCart { get
            {
                double totalPriceOfCart = 0;
                foreach (ShoppingCartProduct item in ShoppingCartProducts)
                {
                    totalPriceOfCart += item.TotalPrice;
                }
                return totalPriceOfCart;
            } }
        public List<ShoppingCartProduct> ShoppingCartProducts { get; set; } = new List<ShoppingCartProduct>();
    }
}
