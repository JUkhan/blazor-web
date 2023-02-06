using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;



namespace BlazorWeb.BLL.Features.Element.Commands
{
  public static class DeleteElement
  {
    public record ElementDeleteCommand(int Id) : IRequest<bool> { }


    public class ElementDeleteHandler : IRequestHandler<ElementDeleteCommand, bool>
    {
      private readonly IElementRepository elementRepository;
      private readonly IMapper mapper;

      public ElementDeleteHandler(IElementRepository elementRepository, IMapper mapper)
      {
        this.elementRepository = elementRepository ?? throw new ArgumentNullException(nameof(ElementRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<bool> Handle(ElementDeleteCommand request, CancellationToken cancellationToken)
      {
        var data = await elementRepository.GetByIdAsync(request.Id);
        if (data != null)
        {
          await elementRepository.DeleteAsync(data);
          return true;
        }
        return false;

      }
    }

  }
}

