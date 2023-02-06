
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BlazorWeb.BLL.Features.Element.Queries.GetElementList;
using static BlazorWeb.BLL.Features.Element.Commands.SaveElement;
using BlazorWeb.Shared;
using static BlazorWeb.BLL.Features.Element.Commands.UpdateElement;
using static BlazorWeb.BLL.Features.Element.Commands.DeleteElement;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWeb.Server.Controllers
{
  [Route("api/[controller]")]
  public class ElementController : Controller
  {
    private readonly IMediator _mediator;

    public ElementController(IMediator _mediator)
    {
      this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
    }

    [HttpGet("{id}")]
    public async Task<IEnumerable<ElementDto>> Get(int id) => await _mediator.Send(new ElementListQuery(id));



    // POST api/values
    [HttpPost]
    public async Task<ElementDto> Post([FromBody] ElementSaveCommand saveCommand) => await _mediator.Send(saveCommand);


    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<bool> Put(int id, [FromBody] ElementUpdateCommand updateCommand) => await _mediator.Send(updateCommand);


    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id) => await _mediator.Send(new ElementDeleteCommand(id));

  }
}

