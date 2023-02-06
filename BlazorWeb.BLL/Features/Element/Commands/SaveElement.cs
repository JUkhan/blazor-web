using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;
using BlazorWeb.Shared;
using FluentValidation;

namespace BlazorWeb.BLL.Features.Element.Commands
{
  public static class SaveElement
  {
    public record ElementSaveCommand(string Type, int Width, int Height, int WindowId) : IRequest<ElementDto> { }


    public class ElementSaveHandler : IRequestHandler<ElementSaveCommand, ElementDto>
    {
      private readonly IElementRepository elementRepository;
      private readonly IMapper mapper;

      public ElementSaveHandler(IElementRepository elementRepository, IMapper mapper)
      {
        this.elementRepository = elementRepository ?? throw new ArgumentNullException(nameof(ElementRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<ElementDto> Handle(ElementSaveCommand request, CancellationToken cancellationToken)
      {
        var data = mapper.Map<DAL.Entities.Element>(request);
        var res = await elementRepository.AddAsync(data);
        return mapper.Map<ElementDto>(res);

      }
    }

    public class ElementSaveCommandValidator : AbstractValidator<ElementSaveCommand>
    {
      public ElementSaveCommandValidator()
      {
        RuleFor(p => p.Type)
        .NotEmpty().WithMessage("{Type} is required.")
        .NotNull()
        .MaximumLength(250).WithMessage("{Type} must not exceed 250 characters.");

        RuleFor(p => p.Width)
           .NotEmpty().WithMessage("{State} is required.")
           .NotNull();
        RuleFor(p => p.Height)
           .NotEmpty().WithMessage("{Height} is required.")
           .NotNull();


      }
    }

  }
}

