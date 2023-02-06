using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;



namespace BlazorWeb.BLL.Features.Order.Commands
{
  public static class DeleteOrder
  {
    public record OrderDeleteCommand(int Id) : IRequest<bool> { }


    public class OrderDeleteHandler : IRequestHandler<OrderDeleteCommand, bool>
    {
      private readonly IOrderRepository orderRepository;
      private readonly IMapper mapper;

      public OrderDeleteHandler(IOrderRepository orderRepository, IMapper mapper)
      {
        this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<bool> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
      {
        var data = await orderRepository.GetByIdAsync(request.Id);
        if (data != null)
        {
          await orderRepository.DeleteAsync(data);
          return true;
        }
        return false;

      }
    }

  }
}

