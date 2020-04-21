using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;

namespace Gym.Domain.Entities
{
    [Table("dbo.Plans")]
    public class PlanEntity : GuidEntity
    {
        public string Description { get; set; }
        public float Value { get; set; }
    }
}
