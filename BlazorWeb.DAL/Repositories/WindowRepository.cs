using System;
using BlazorWeb.DAL.Entities;
using BlazorWeb.DAL.Persistence;
using BlazorWeb.Shared;

namespace BlazorWeb.DAL.Repositories
{
  public class WindowRepository : RepositoryBase<Window>, IWindowRepository
  {
    private readonly DataContext ctx;
    public WindowRepository(DataContext context) : base(context)
    {
      ctx = context;

    }

    public  List<WindowDto> GetWindowsByOrderId(int orderId)
    {
      return ctx.Windows.Where(w => w.OrderId == orderId)
      .Select(w => new WindowDto { Id = w.Id, OrderId=w.OrderId, Name = w.Name, Quantity = w.Quantity, TotalSubElement = ctx.Elements.Where(t => t.WindowId == w.Id).Count() }).ToList();
      
    }
  }
}

