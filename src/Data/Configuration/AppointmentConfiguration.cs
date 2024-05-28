using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment.Domain.Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment.Domain.Appointment> builder)
    {
        builder.ToTable(nameof(Appointment.Domain.Appointment));

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.DeletedAt)
            .IsRequired(false);
        
        builder.Property(x => x.PatientId)
            .IsRequired();
        
        builder.Property(x => x.DoctorId)
            .IsRequired();
        
        builder.HasOne(x => x.Patient)
            .WithMany()
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Doctor)
            .WithMany()
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}