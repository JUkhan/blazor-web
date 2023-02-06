using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;
using BlazorWeb.Shared;
using FluentValidation;

namespace BlazorWeb.BLL.Features.Order.Commands
{
  public static class SaveOrder
  {
    public record OrderSaveCommand(string Name, string State) : IRequest<OrderDto> { }


    public class OrderSaveHandler : IRequestHandler<OrderSaveCommand, OrderDto>
    {
      private readonly IOrderRepository orderRepository;
      private readonly IMapper mapper;

      public OrderSaveHandler(IOrderRepository orderRepository, IMapper mapper)
      {
        this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<OrderDto> Handle(OrderSaveCommand request, CancellationToken cancellationToken)
      {
        var data = mapper.Map<DAL.Entities.Order>(request);
        var res = await orderRepository.AddAsync(data);
        return mapper.Map<OrderDto>(res);

      }
    }

    public class OrderSaveCommandValidator : AbstractValidator<OrderSaveCommand>
    {
      public OrderSaveCommandValidator()
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

