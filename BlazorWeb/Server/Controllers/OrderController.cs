
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BlazorWeb.BLL.Features.Order.Queries.GetOrderList;
using static BlazorWeb.BLL.Features.Order.Commands.SaveOrder;
using BlazorWeb.Shared;
using static BlazorWeb.BLL.Features.Order.Commands.UpdateOrder;
using static BlazorWeb.BLL.Features.Order.Commands.DeleteOrder;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWeb.Server.Controllers
{
  [Route("api/[controller]")]
  public class OrderController : Controller
  {
    private readonly IMediator _mediator;

    public OrderController(IMediator _mediator)
    {
      this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
    }

    [HttpGet]
    public async Task<IEnumerable<OrderDto>> Get() => await _mediator.Send(new OrderListQuery());


    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public async Task<OrderDto> Post([FromBody] OrderSaveCommand saveCommand) => await _mediator.Send(saveCommand);


    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<bool> Put(int id, [FromBody] OrderUpdateCommand updateCommand) => await _mediator.Send(updateCommand);


    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id) => await _mediator.Send(new OrderDeleteCommand(id));

  }
}

