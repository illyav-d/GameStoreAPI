namespace GameStoreAPI.Data.Entities
{
    public class OrderEntity : IOrderEntity
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public double TotalPriceInEuro { get; set; }
        public string GameTitles { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
