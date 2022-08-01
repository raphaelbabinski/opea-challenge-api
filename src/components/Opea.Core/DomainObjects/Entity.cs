using System;

namespace Opea.Core.DomainObjects
{
    public abstract class Entity
    {
        public long Id { get; set; }

        public Guid Identifier { get; set; }

        protected Entity()
        {
            Identifier = Guid.NewGuid();
        }
    }
}