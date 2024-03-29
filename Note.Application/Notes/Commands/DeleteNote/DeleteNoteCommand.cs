﻿using MediatR;
using System;


namespace Note.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid UserId { get; set; }

        public Guid Id { get; set; }
    }
}
