using Note.Persistence;
using System;

namespace Notes.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly NotesDbContext _context;

        public TestCommandBase()
        {
            _context = NotesContextFactory.Create();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(_context);
        }
    }
}
