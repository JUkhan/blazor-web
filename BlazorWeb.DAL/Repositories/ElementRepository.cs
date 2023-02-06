using System;
using BlazorWeb.DAL.Entities;
using BlazorWeb.DAL.Persistence;

namespace BlazorWeb.DAL.Repositories
{
	public class ElementRepository : RepositoryBase<Element>, IElementRepository
	{
		public ElementRepository(DataContext context):base(context)
		{
		}
	}
}

