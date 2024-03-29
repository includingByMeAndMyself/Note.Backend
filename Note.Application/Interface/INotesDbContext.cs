﻿using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Note.Domain;


namespace Note.Application.Interface
{
    public interface INotesDbContext
    {
        DbSet<Domain.Note> Notes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
