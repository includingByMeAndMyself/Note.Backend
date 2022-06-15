using MediatR;
using Note.Application.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Note.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler
        : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public CreateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var note = new Domain.Note
            {
                UserId = request.UserId,
                Title = request.Titel,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditeDate = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
