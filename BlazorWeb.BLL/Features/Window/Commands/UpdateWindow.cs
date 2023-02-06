using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;
using FluentValidation;

namespace BlazorWeb.BLL.Features.Window.Commands
{
  public static class UpdateWindow
  {
    public record WindowUpdateCommand(int Id, string Name, int Quantity, int OrderId) : IRequest<bool> { }


    public class WindowUpdateHandler : IRequestHandler<WindowUpdateCommand, bool>
    {
      private readonly IWindowRepository windowRepository;
      private readonly IMapper mapper;

      public WindowUpdateHandler(IWindowRepository windowRepository, IMapper mapper)
      {
        this.windowRepository = windowRepository ?? throw new ArgumentNullException(nameof(WindowRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<bool> Handle(WindowUpdateCommand request, CancellationToken cancellationToken)
      {
        var data = await windowRepository.GetByIdAsync(request.Id);
        if (data != null)
        {
          mapper.Map<WindowUpdateCommand, DAL.Entities.Window>(request, data);
          await windowRepository.UpdateAsync(data);
          return true;
        }
        return false;

      }
    }

    public class WindowUpdateCommandValidator : AbstractValidator<WindowUpdateCommand>
    {
      public WindowUpdateCommandValidator()
      {
        RuleFor(p => p.Name)
        .NotEmpty().WithMessage("{Name} is required.")
        .NotNull()
        .MaximumLength(150).WithMessage("{Name} must not exceed 150 characters.");

        RuleFor(p => p.Quantity)
           .NotEmpty().WithMessage("{State} is required.")
           .NotNull();


      }
    }

  }
}

