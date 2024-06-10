namespace GameStoreAPI.Business.Models
{
    public class Platform
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<GameProduct> GameProducts { get; set; }
    }
}
