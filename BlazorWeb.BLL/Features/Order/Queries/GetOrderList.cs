using System;
using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;
using BlazorWeb.Shared;
using System.Collections.Generic;

namespace BlazorWeb.BLL.Features.Order.Queries
{
  public static class GetOrderList
  {
    public record OrderListQuery() : IRequest<List<OrderDto>> { }


    public class OrderListHandler : IRequestHandler<OrderListQuery, List<OrderDto>>
    {
      private readonly IOrderRepository orderRepository;
      private readonly IMapper mapper;

      public OrderListHandler(IOrderRepository orderRepository, IMapper mapper)
      {
        this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<List<OrderDto>> Handle(OrderListQuery request, CancellationToken cancellationToken)
      {
          var res = await orderRepository.GetAllAsync();
          return mapper.Map<List<OrderDto>>(res);
      }
    }

  }
}

