using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Note.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Note.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler 
        : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly INoteDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(INoteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NoteListVm> Handle(GetNoteListQuery request,
            CancellationToken cancellation)
        {
            var notesQuery = await _dbContext.Notes
                .Where(note => note.UserId == request.UserId)
                .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);

            return new NoteListVm { Notes = notesQuery };
        }
    }
}
