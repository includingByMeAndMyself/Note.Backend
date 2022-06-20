using Microsoft.EntityFrameworkCore;
using Note.Application.Interface;
using Note.Persistence.EntityTypeConfiguration;

namespace Note.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Domain.Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
