
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BlazorWeb.BLL.Features.Window.Queries.GetWindowList;
using static BlazorWeb.BLL.Features.Window.Commands.SaveWindow;
using BlazorWeb.Shared;
using static BlazorWeb.BLL.Features.Window.Commands.UpdateWindow;
using static BlazorWeb.BLL.Features.Window.Commands.DeleteWindow;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWeb.Server.Controllers
{
  [Route("api/[controller]")]
  public class WindowController : Controller
  {
    private readonly IMediator _mediator;

    public WindowController(IMediator _mediator)
    {
      this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IEnumerable<WindowDto>> Get(int id) => await _mediator.Send(new WindowListQuery(id));


    // POST api/values
    [HttpPost]
    public async Task<WindowDto> Post([FromBody] WindowSaveCommand saveCommand) => await _mediator.Send(saveCommand);


    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<bool> Put(int id, [FromBody] WindowUpdateCommand updateCommand) => await _mediator.Send(updateCommand);


    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id) => await _mediator.Send(new WindowDeleteCommand(id));

  }
}

