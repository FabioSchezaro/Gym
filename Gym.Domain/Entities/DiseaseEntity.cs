using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;

namespace Gym.Domain.Entities
{
    [Table("dbo.Disease")]
    public class DiseaseEntity : GuidEntity
    {
        public string Description { get; set; }
    }
}
