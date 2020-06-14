using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;

namespace Gym.Domain.Entities
{
    [Table("dbo.Role")]
    public class RoleEntity : GuidEntity
    {
        public string Description { get; set; }
    }
}
