using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;
using System;

namespace Gym.Domain.Entities
{
    [Table("dbo.Metrics")]
    public class MetricsEntity : GuidEntity
    {
        public Guid IdPeople { get; set; }
        public float Biceps { get; set; }
        public float Breastplate { get; set; }
        public float Hip { get; set; }
        public float Abdomen { get; set; }
        public float Thighs { get; set; }
        public float Calf { get; set; }
    }
}
