
using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;
using BlazorWeb.Shared;


namespace BlazorWeb.BLL.Features.Window.Queries
{
  public static class GetWindowList
  {
    public record WindowListQuery(int OrderId) : IRequest<List<WindowDto>> { }


    public class WindowListHandler : IRequestHandler<WindowListQuery, List<WindowDto>>
    {
      private readonly IWindowRepository windowRepository;
      private readonly IMapper mapper;

      public WindowListHandler(IWindowRepository windowRepository, IMapper mapper)
      {
        this.windowRepository = windowRepository ?? throw new ArgumentNullException(nameof(windowRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public  Task<List<WindowDto>> Handle(WindowListQuery request, CancellationToken cancellationToken)
      {

           // var res = await windowRepository.GetAsync(el => el.OrderId == request.OrderId);
           var res = windowRepository.GetWindowsByOrderId(request.OrderId);
           return Task.FromResult(res);


      }
    }

  }
}

