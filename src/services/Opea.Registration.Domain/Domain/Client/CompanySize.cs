using Opea.Core.DomainObjects;
using System;

namespace Opea.Registration.Business.Domain.Client
{
    public class CompanySize : Entity, IAggregateRoot
    {
        public string Name { get; set; }

        protected CompanySize() { }

        public CompanySize(long? id, Guid identifier, string name)
        {
            if (id.HasValue) Id = id.Value;
            Identifier = identifier;
            Name = name;
        }
    }
}
