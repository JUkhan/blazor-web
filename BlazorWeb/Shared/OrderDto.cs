using System;
namespace BlazorWeb.Shared
{
  public class OrderDto
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? State { get; set; }
    public bool IsUpdate { get; set; } = false;
    public bool IsExpand { get; set; } = false;
  }
}

