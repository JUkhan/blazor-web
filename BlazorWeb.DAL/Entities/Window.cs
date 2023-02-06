using System;
using BlazorWeb.DAL.Entities;

namespace BlazorWeb.DAL.Entities
{
  public class Window : EntityBase
  {
    public string? Name { get; set; }
    public int? Quantity { get; set; }
    public int OrderId { get; protected set; }
    public Order Order { get; set; }
    public List<Element> Elements { get; }

  }
}

