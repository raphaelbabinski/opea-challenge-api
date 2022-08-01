using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Opea.Registration.Data.Mapping.Client
{
    public class ClientMapping : IEntityTypeConfiguration<Business.Domain.Client.Client>
    {
        public void Configure(EntityTypeBuilder<Business.Domain.Client.Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Identifier)
                .IsRequired()
                .HasDefaultValue(Guid.NewGuid());

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Clients");
        }
    }
}