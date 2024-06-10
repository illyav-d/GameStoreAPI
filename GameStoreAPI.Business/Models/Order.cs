namespace GameStoreAPI.Business.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public double TotalPriceInEuro { get; set; }
        public string[] GameTitles { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
