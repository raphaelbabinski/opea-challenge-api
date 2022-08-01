using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opea.Registration.Business.Domain.Client;
using System;

namespace Opea.Registration.Data.Mapping.Client
{
    public class CompanySizeMapping : IEntityTypeConfiguration<CompanySize>
    {
        public void Configure(EntityTypeBuilder<CompanySize> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Identifier)
                .IsRequired()
                .HasDefaultValue(Guid.NewGuid());

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("CompanySizes");
        }
    }
}
