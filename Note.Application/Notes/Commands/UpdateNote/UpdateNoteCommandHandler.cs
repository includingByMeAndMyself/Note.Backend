using MediatR;
using Microsoft.EntityFrameworkCore;
using Note.Application.Common.Exceptions;
using Note.Application.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Note.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler
        : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _dbContext;

        public UpdateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Notes.FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Domain.Note), request.Id); 
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditeDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
