using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;
using System;

namespace Gym.Domain.Entities
{
    [Table("dbo.People_x_Disease")]
    public class PeopleDiseaseEntity : GuidEntity
    {
        public Guid IdPeople { get; set; }
        public Guid IdDisease { get; set; }
    }
}
