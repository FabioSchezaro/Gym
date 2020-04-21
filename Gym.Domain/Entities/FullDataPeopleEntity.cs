using Gym.Domain.Entities;
using System.Collections.Generic;

namespace Gym.Domain.Entities
{
    public class FullDataPeopleEntity
    {
        public PeopleEntity People { get; set; }
        public UserEntity User { get; set; }
        public ClientEntity Client { get; set; }
        public AddressEntity Address { get; set; }
        public PhisicalAvaliationEntity PhisicalAvaliation { get; set; }
        public MetricsEntity Metrics { get; set; }

        public List<TelephoneEntity> TelephonesCollection { get; set; }
        public List<DiseaseEntity> DiseasesCollection { get; set; }
    }
}
