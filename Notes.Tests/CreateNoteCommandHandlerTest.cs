﻿using Microsoft.EntityFrameworkCore;
using Note.Application.Notes.Commands.CreateNote;
using Notes.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Notes.Tests
{
    public class CreateNoteCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateNoteCommandHandler(_context);
            var noteName = "note name";
            var noteDetails = "note details";

            //Act
            var noteId = await handler.Handle(
                new CreateNoteCommand
                {
                    Titel = noteName,
                    Details = noteDetails,
                    UserId = NotesContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await _context.Notes.SingleOrDefaultAsync(note =>
                note.Id == noteId && note.Title == noteName &&
                note.Details == noteDetails));
        }
    }
}
