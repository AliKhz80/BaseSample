using Application.Features.SampleModel.Commands.CreateSampleModel;
using Application.Features.SampleModel.Commands.DeleteSampleModel;
using Application.Features.SampleModel.Commands.UpdateSampleModel;
using Application.Features.SampleModel.Queries.GetAllSampleModels;
using Application.Features.SampleModel.Queries.GetSampleModelById;
using Application.Features.SampleModel.Queries.GetSampleModelsByFilter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleProject.API.Controllers;

public class SampleModelController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetSampleModelByIdQuery(id), cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllSampleModelsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetByFilter")]
    
    public async Task<IActionResult> GetByFilter([FromQuery] GetSampleModelsByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    

    [HttpPost("Create")]
    //[Authorize]
   
    public async Task<IActionResult> Create(CreateSampleModelCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPut("Update")]
    //[Authorize]
  
    public async Task<IActionResult> Update(UpdateSampleModelCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    //[Authorize]
   
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteSampleModelCommand(id), cancellationToken);
        return Ok(result);
    }

    
}
