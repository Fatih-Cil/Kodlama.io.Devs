using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, CreatedProgrammingTechnologyDto>().ReverseMap();

            CreateMap<ProgrammingTechnology, DeleteProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, DeletedProgrammingTechnologyDto>().ReverseMap();

            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, UpdatedProgrammingTechnologyDto>().ReverseMap();

        }

       

    }
}
