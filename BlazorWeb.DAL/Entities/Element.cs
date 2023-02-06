using System;
namespace BlazorWeb.DAL.Entities
{
  public class Element : EntityBase
  {
    public string? Type { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int WindowId { get; set; }
    public Window Window { get; set; }

  }
}

