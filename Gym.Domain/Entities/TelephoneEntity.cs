using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;
using System;

namespace Gym.Domain.Entities
{
    [Table("dbo.Telephone")]
    public class TelephoneEntity : GuidEntity
    {
        public Guid IdPeople { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
