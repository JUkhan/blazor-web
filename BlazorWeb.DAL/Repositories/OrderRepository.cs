using System;
using BlazorWeb.DAL.Entities;
using BlazorWeb.DAL.Persistence;

namespace BlazorWeb.DAL.Repositories
{
  public class OrderRepository : RepositoryBase<Order>, IOrderRepository
  {

    public OrderRepository(DataContext dbContext) : base(dbContext)
    {
    }


  }
}

