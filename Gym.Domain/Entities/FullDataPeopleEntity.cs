using Gym.Domain.Entities;
using System.Collections.Generic;

namespace Gym.Domain.Entities
{
    public class FullDataPeopleEntity
    {
        public PeopleEntity People { get; set; }
        public UserEntity User { get; set; }
        public AddressEntity Address { get; set; }
        public List<TelephoneEntity> Telephones { get; set; }
    }
}
