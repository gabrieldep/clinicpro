using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class RegistrationConfiguration : IEntityTypeConfiguration<Registration.Domain.Registration>
{
    public void Configure(EntityTypeBuilder<Registration.Domain.Registration> builder)
    {
        builder.ToTable(nameof(Registration.Domain.Registration));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.DeletedAt)
            .IsRequired(false);
    }
}