using Opea.Core.DomainObjects;
using System;

namespace Opea.Registration.Business.Domain.Client
{
    public class Client : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public long CompanySizeId { get; set; }

        public virtual CompanySize CompanySize { get; set; }

        protected Client() { }

        public Client(long? id, Guid identifier, string name, long companySizeId)
        {
            if (id.HasValue) Id = id.Value;
            Identifier = identifier;
            Name = name;
            CompanySizeId = companySizeId;

            Validate();
        }

        public void Validate()
        {
            Validations.ValidateIsEmpty(Name, "O campo nome é obrigatório");
            Validations.ValidateIsEmpty(CompanySizeId, "O campo Porte da Empresa é obrigatório");
        }
    }
}