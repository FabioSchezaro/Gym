using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;
using System;

namespace Gym.Domain.Entities
{
    [Table("dbo.People")]
    public class PeopleEntity : GuidEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public Guid IdRole { get; set; }
        public string Active { get; set; }
    }
}
