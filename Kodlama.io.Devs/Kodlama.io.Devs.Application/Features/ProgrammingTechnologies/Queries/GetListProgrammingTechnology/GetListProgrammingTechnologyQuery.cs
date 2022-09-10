using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology
{
    public class GetListProgrammingTechnologyQuery:IRequest<ProgrammingTechnologiesListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingTechnologyQueryHandler : IRequestHandler<GetListProgrammingTechnologyQuery, ProgrammingTechnologiesListModel>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingTechnologiesListModel> Handle(GetListProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                //join gerekli olan listelerde yapılması gerekenler var. 
                IPaginate<ProgrammingTechnology> programmingTechnologies = await _programmingTechnologyRepository.GetListAsync(include:
                      m => m.Include(c => c.ProgrammingLanguage),
                      index: request.PageRequest.Page,
                      size: request.PageRequest.PageSize
                      );
                ProgrammingTechnologiesListModel mappedprogrammingTechnologiesListModel = _mapper.Map<ProgrammingTechnologiesListModel>(programmingTechnologies);
                return mappedprogrammingTechnologiesListModel;
                    
                                                    
            }
        }
    }
}
