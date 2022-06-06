using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Note.Persistence.EntityTypeConfiguration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Domain.Note>
    {
        public void Configure(EntityTypeBuilder<Domain.Note> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
