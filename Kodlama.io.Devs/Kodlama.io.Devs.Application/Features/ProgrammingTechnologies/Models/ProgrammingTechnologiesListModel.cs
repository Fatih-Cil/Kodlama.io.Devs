using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models
{
    public class ProgrammingTechnologiesListModel : BasePageableModel
    {
        public IList<ProgrammingTechnologiesListDto> Items { get; set; }
    }
}
