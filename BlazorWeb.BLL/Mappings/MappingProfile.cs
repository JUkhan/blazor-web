using System;
using AutoMapper;
using BlazorWeb.Shared;
using static BlazorWeb.BLL.Features.Order.Commands.SaveOrder;
using static BlazorWeb.BLL.Features.Order.Commands.UpdateOrder;
using static BlazorWeb.BLL.Features.Window.Commands.SaveWindow;
using static BlazorWeb.BLL.Features.Window.Commands.UpdateWindow;
using static BlazorWeb.BLL.Features.Element.Commands.SaveElement;
using static BlazorWeb.BLL.Features.Element.Commands.UpdateElement;

namespace BlazorWeb.BLL.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<DAL.Entities.Order, OrderDto>();
      CreateMap<OrderSaveCommand, DAL.Entities.Order>();
      CreateMap<OrderUpdateCommand, DAL.Entities.Order>();

      CreateMap<DAL.Entities.Window, WindowDto>();
      CreateMap<WindowSaveCommand, DAL.Entities.Window>();
      CreateMap<WindowUpdateCommand, DAL.Entities.Window>();

      CreateMap<DAL.Entities.Element, ElementDto>();
      CreateMap<ElementSaveCommand, DAL.Entities.Element>();
      CreateMap<ElementUpdateCommand, DAL.Entities.Element>();
    }
  }
}

