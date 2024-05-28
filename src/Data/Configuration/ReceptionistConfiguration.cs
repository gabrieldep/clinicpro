using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class ReceptionistConfiguration : IEntityTypeConfiguration<Receptionist.Domain.Receptionist>
{
    public void Configure(EntityTypeBuilder<Receptionist.Domain.Receptionist> builder)
    {
    }
}