using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;
using System;

namespace Gym.Domain.Entities
{
    [Table("dbo.Client")]
    public class ClientEntity : GuidEntity
    {
        public Guid IdPeople { get; set; }
        public PlanEntity Plan { get; set; }
        public DueDayEntity DueDay { get; set; }
    }
}
