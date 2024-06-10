using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.Data.Entities
{
    public class PlatformEntity : INameableEntity
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        //Navigationproperty
        public List<GameProductEntity> GameProducts { get; set; }
    }
}