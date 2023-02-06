
using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;
using BlazorWeb.Shared;


namespace BlazorWeb.BLL.Features.Element.Queries
{
  public static class GetElementList
  {
    public record ElementListQuery(int WindowId) : IRequest<List<ElementDto>> { }


    public class ElementListHandler : IRequestHandler<ElementListQuery, List<ElementDto>>
    {
      private readonly IElementRepository elementRepository;
      private readonly IMapper mapper;

      public ElementListHandler(IElementRepository elementRepository, IMapper mapper)
      {
        this.elementRepository = elementRepository ?? throw new ArgumentNullException(nameof(elementRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<List<ElementDto>> Handle(ElementListQuery request, CancellationToken cancellationToken)
      {

        var res = await elementRepository.GetAsync(el => el.WindowId == request.WindowId);

        return mapper.Map<List<ElementDto>>(res);


      }
    }

  }
}

