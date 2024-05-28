using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class PatientConfiguration : IEntityTypeConfiguration<Patient.Domain.Patient>
{
    public void Configure(EntityTypeBuilder<Patient.Domain.Patient> builder)
    {
    }
}