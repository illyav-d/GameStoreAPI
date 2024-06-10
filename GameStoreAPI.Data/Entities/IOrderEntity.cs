namespace GameStoreAPI.Data.Entities
{
    public interface IOrderEntity : IEntity
    {
        int CustomerID { get; set; }
        string GameTitles { get; set; }
        int ID { get; set; }
        DateTime OrderDate { get; set; }
        double TotalPriceInEuro { get; set; }
    }
}