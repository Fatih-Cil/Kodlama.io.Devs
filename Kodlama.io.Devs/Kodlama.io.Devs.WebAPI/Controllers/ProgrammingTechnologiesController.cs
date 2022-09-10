using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
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


    }
}
