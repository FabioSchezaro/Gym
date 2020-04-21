using Dapper.Contrib.Extensions;
using Gym.Domain.Shared;
using System;

namespace Gym.Domain.Entities
{
    [Table("dbo.Address")]
    public class AddressEntity : GuidEntity
    {
        public Guid IdPeople { get; set; }
        public string Cep { get; set; }
        public string NeighBorhood { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
    }
}
