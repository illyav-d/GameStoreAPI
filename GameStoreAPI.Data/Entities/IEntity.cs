namespace GameStoreAPI.Data.Entities
{
    public interface IEntity
    {
        int ID { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}
