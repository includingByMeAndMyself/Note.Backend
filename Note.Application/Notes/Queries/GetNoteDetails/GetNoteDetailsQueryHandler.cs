﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Note.Application.Common.Exceptions;
using Note.Application.Interface;
using System.Threading;
using System.Threading.Tasks;


namespace Note.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler
        : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(INotesDbContext  dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if(entity == null || entity.UserId != request.Id)
            {
                throw new NotFoundException(nameof(Domain.Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
