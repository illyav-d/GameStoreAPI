namespace GameStoreAPI.Data.Entities
{
    public interface INameableEntity: IEntity
    {
        string Name { get; set; }
    }
}