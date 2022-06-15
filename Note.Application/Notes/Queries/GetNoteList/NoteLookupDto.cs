using AutoMapper;
using Note.Application.Common.Mappings;
using System;

namespace Note.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Domain.Note>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Note, NoteLookupDto>()
                .ForMember(noteVm => noteVm.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Title, opt => opt.MapFrom(note => note.Title));
        }
    }
}
