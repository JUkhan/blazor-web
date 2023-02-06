using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;
using FluentValidation;

namespace BlazorWeb.BLL.Features.Element.Commands
{
  public static class UpdateElement
  {
    public record ElementUpdateCommand(int Id, string Type, int? Width, int? Height, int WindowId) : IRequest<bool> { }


    public class ElementUpdateHandler : IRequestHandler<ElementUpdateCommand, bool>
    {
      private readonly IElementRepository elementRepository;
      private readonly IMapper mapper;

      public ElementUpdateHandler(IElementRepository elementRepository, IMapper mapper)
      {
        this.elementRepository = elementRepository ?? throw new ArgumentNullException(nameof(ElementRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<bool> Handle(ElementUpdateCommand request, CancellationToken cancellationToken)
      {
        var data = await elementRepository.GetByIdAsync(request.Id);
        if (data != null)
        {
          mapper.Map<ElementUpdateCommand, DAL.Entities.Element>(request, data);
          await elementRepository.UpdateAsync(data);
          return true;
        }
        return false;

      }
    }

    public class ElementUpdateCommandValidator : AbstractValidator<ElementUpdateCommand>
    {
      public ElementUpdateCommandValidator()
      {
        RuleFor(p => p.Type)
         .NotEmpty().WithMessage("{Type} is required.")
         .NotNull()
         .MaximumLength(250).WithMessage("{Type} must not exceed 250 characters.");

        RuleFor(p => p.Width)
           .NotEmpty().WithMessage("{Width} is required.")
           .NotNull();

        RuleFor(p => p.Height)
           .NotEmpty().WithMessage("{Height} is required.")
           .NotNull();


      }
    }

  }
}

