using System;
namespace BlazorWeb.Shared
{
  public class ElementDto
  {
    public int Id { get; set; }
    public string? Type { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int? WindowId { get; set; }

    public bool IsUpdate { get; set; } = false;
    public bool IsExpand { get; set; } = false;
  }
}

