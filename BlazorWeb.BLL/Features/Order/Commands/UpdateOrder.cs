using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;
using FluentValidation;

namespace BlazorWeb.BLL.Features.Order.Commands
{
  public static class UpdateOrder
  {
    public record OrderUpdateCommand(int Id, string Name, string State) : IRequest<bool> { }


    public class OrderUpdateHandler : IRequestHandler<OrderUpdateCommand, bool>
    {
      private readonly IOrderRepository orderRepository;
      private readonly IMapper mapper;

      public OrderUpdateHandler(IOrderRepository orderRepository, IMapper mapper)
      {
        this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<bool> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
      {
        var data = await orderRepository.GetByIdAsync(request.Id);
        if (data != null)
        {
          mapper.Map<OrderUpdateCommand, DAL.Entities.Order>(request, data);
          await orderRepository.UpdateAsync(data);
          return true;
        }
        return false;

      }
    }

    public class OrderUpdateCommandValidator : AbstractValidator<OrderUpdateCommand>
    {
      public OrderUpdateCommandValidator()
      {
        RuleFor(p => p.Name)
        .NotEmpty().WithMessage("{Name} is required.")
        .NotNull()
        .MaximumLength(150).WithMessage("{Name} must not exceed 150 characters.");

        RuleFor(p => p.State)
           .NotEmpty().WithMessage("{State} is required.")
           .NotNull()
        .MaximumLength(50).WithMessage("{State} must not exceed 50 characters.");


      }
    }

  }
}

