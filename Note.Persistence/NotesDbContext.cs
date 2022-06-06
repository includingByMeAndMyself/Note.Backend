﻿using Microsoft.EntityFrameworkCore;
using Note.Application.Interface;
using Note.Persistence.EntityTypeConfiguration;

namespace Note.Persistence
{
    public class NotesDbContext : DbContext, INoteDbContext
    {
        public DbSet<Domain.Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}