using System;
using BlazorWeb.DAL.Entities;
using BlazorWeb.Shared;

namespace BlazorWeb.DAL.Repositories
{
  public interface IWindowRepository : IAsyncRepository<Window>
  {
    public List<WindowDto> GetWindowsByOrderId(int orderId);
  }
}

