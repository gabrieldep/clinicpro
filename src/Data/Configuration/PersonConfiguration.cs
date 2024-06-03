using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class PersonConfiguration : IEntityTypeConfiguration<Person.Domain.Person>
{
    public void Configure(EntityTypeBuilder<Person.Domain.Person> builder)
    {
        builder.ToTable(nameof(Person));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.DeletedAt)
            .IsRequired(false);

        builder.Property(x => x.Name)
            .IsRequired();
        
        builder.Property(x => x.Birth)
            .IsRequired();
        
        builder.Property(x => x.CPF)
            .IsRequired();
    }
}