using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic
{
    public class GetListProgrammingTechnologyByDynamicQuery : IRequest<ProgrammingTechnologiesListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingTechnologyByDynamicQueryHandler : IRequestHandler<GetListProgrammingTechnologyByDynamicQuery, ProgrammingTechnologiesListModel>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingTechnologyByDynamicQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingTechnologiesListModel> Handle(GetListProgrammingTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                //dynamic olarak parametre girildiğinde işleyecek.
                IPaginate<ProgrammingTechnology> programmingTechnologies = await _programmingTechnologyRepository.GetListByDynamicAsync(request.Dynamic,
                    include:
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
