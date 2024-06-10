namespace GameStoreAPI.DTO.Order
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public double TotalPriceInEuro { get; set; }
        public string[] GameTitles { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
