using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;

namespace Gym.Domain.Entities
{
    [Table("dbo.DueDay")]
    public class DueDayEntity : GuidEntity
    {
        public int Day { get; set; }
    }
}
