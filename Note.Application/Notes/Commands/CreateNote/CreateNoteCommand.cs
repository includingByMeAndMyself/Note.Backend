using MediatR;
using System;


namespace Note.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string Titel { get; set; }

        public string Details { get; set; }
    }
}
