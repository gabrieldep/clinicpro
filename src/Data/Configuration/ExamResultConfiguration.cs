using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult.Domain.ExamResult>
{
    public void Configure(EntityTypeBuilder<ExamResult.Domain.ExamResult> builder)
    {
        builder.ToTable(nameof(ExamResult.Domain.ExamResult));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.DeletedAt)
            .IsRequired(false);
    }
}