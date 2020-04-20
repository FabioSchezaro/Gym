using Gym.Domain.Entities;

namespace Gym.Domain.Entities
{
    public class FullDataPeopleEntity
    {
        public PeopleEntity People { get; set; }
        public UserEntity User { get; set; }
    }
}
