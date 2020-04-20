using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;
using System;

namespace Gym.Domain.Entities
{
    [Table("dbo.Users")]
    public class UserEntity : GuidEntity
    {
        public Guid IdPeople { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
