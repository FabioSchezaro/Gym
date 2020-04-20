using Dapper.Contrib.Extensions;
using System;

namespace Gym.Domain.Shared
{
    public abstract class GuidEntity
    {
        private Guid _id;

        [ExplicitKey]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value == Guid.Empty)
                {
                    _id = Guid.NewGuid();
                }
                else
                {
                    _id = value;
                }
            }
        }
    }
}
