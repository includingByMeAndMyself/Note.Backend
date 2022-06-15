using System.Collections.Generic;


namespace Note.Application.Notes.Queries.GetNoteList
{
    public class NoteListVm
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}
