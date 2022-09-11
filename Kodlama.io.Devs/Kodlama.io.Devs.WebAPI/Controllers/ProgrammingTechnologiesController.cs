using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologiesController : BaseController
    {

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyCommand createProgrammingTechnologyCommand)
        {
         CreatedProgrammingTechnologyDto result =  await Mediator.Send(createProgrammingTechnologyCommand);
            return Created("", result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingTechnologyCommand deleteProgrammingTechnologyCommand)
        {
            DeletedProgrammingTechnologyDto result = await Mediator.Send(deleteProgrammingTechnologyCommand);
            return Created("", result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyCommand updateProgrammingTechnologyCommand)
        {
            UpdatedProgrammingTechnologyDto result = await Mediator.Send(updateProgrammingTechnologyCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingTechnologyQuery getListProgrammingTechnologyQuery = new GetListProgrammingTechnologyQuery { PageRequest = pageRequest };
            ProgrammingTechnologiesListModel result = await Mediator.Send(getListProgrammingTechnologyQuery);
            return Ok(result);

        }

        [HttpPost("Getlist/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody] Dynamic dynamic)
        {
            GetListProgrammingTechnologyByDynamicQuery getListProgrammingTechnologyByDynamicQuery = new GetListProgrammingTechnologyByDynamicQuery { PageRequest = pageRequest, Dynamic=dynamic };
            ProgrammingTechnologiesListModel result = await Mediator.Send(getListProgrammingTechnologyByDynamicQuery);
            return Ok(result);

//Örnek sorgu aşağıdaki gibi yapılabilir.  isminde net veya j harfi olanları listeliyoruz.Filters bölümünde virgul atarak birden çok parametre geçilebilir. operator "gte" büyük eşit demek. "lte" küçük eşit dmeek. "eq" eşit demek.
//            {
//  "sort": [
//    {
//      "field": "name",
//      "dir": "asc"
//    }
//  ],
//  "filter": {
//    "field": "name",
//    "operator": "contains",
//    "value": "net",
//    "logic": "or",
//    "filters": [
//{
//      "field": "name",
//      "operator": "contains",
//      "value": "j"
//    }
//]
//  }
//}

        }

    }
}
