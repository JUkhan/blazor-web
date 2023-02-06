using System;
namespace BlazorWeb.DAL.Entities
{
  public class Order : EntityBase
  {
    public string? Name { get; set; }
    public string? State { get; set; }
    public List<Window> Windows { get; }
  }
}

