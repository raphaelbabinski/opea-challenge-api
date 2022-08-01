using System;

namespace Opea.Registration.BFF.Models.Client
{
    public class ClientDTO
    {
        public long Id { get; set; }
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public long CompanySizeId { get; set; }
        public CompanySizeDTO CompanySize { get; set; }
    }
}
