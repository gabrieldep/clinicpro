using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor.Domain.Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor.Domain.Doctor> builder)
    {
    }
}