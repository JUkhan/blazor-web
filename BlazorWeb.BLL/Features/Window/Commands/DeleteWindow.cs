using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;



namespace BlazorWeb.BLL.Features.Window.Commands
{
  public static class DeleteWindow
  {
    public record WindowDeleteCommand(int Id) : IRequest<bool> { }


    public class WindowDeleteHandler : IRequestHandler<WindowDeleteCommand, bool>
    {
      private readonly IWindowRepository windowRepository;
      private readonly IMapper mapper;

      public WindowDeleteHandler(IWindowRepository windowRepository, IMapper mapper)
      {
        this.windowRepository = windowRepository ?? throw new ArgumentNullException(nameof(WindowRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<bool> Handle(WindowDeleteCommand request, CancellationToken cancellationToken)
      {
        var data = await windowRepository.GetByIdAsync(request.Id);
        if (data != null)
        {
          await windowRepository.DeleteAsync(data);
          return true;
        }
        return false;

      }
    }

  }
}

