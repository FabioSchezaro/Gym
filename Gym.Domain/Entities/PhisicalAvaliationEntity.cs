using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;
using System;

namespace Gym.Domain.Entities
{
    [Table("dbo.PhisicalAvaliation")]
    public class PhisicalAvaliationEntity : GuidEntity
    {
        public Guid IdPeople { get; set; }
        public float Weight { get; set; }
        public float Reight { get; set; }
        public int FatPercent { get; set; }
    }
}
