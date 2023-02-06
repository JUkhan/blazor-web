using System;
namespace BlazorWeb.Shared
{
  public class WindowDto
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? Quantity { get; set; }
    public int OrderId { get; set; }
    public int TotalSubElement { get; set; }
    public bool IsUpdate { get; set; } = false;
    public bool IsExpand { get; set; } = false;
  }
}

