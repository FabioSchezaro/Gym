using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;
using System;

namespace Gym.Domain.Entities
{
    [Table("dbo.Client")]
    public class ClientEntity : GuidEntity
    {
        public Guid IdPeople { get; set; }
        public Guid IdPlan { get; set; }
        public Guid IdDueDay { get; set; }

        public PlanEntity Plan { get; set; }
        public DueDayEntity DueDay { get; set; }
    }
}
