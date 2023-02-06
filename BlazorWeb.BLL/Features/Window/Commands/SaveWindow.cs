using AutoMapper;
using MediatR;
using BlazorWeb.DAL.Repositories;
using BlazorWeb.Shared;
using FluentValidation;

namespace BlazorWeb.BLL.Features.Window.Commands
{
  public static class SaveWindow
  {
    public record WindowSaveCommand(string Name, int Quantity, int OrderId) : IRequest<WindowDto> { }


    public class WindowSaveHandler : IRequestHandler<WindowSaveCommand, WindowDto>
    {
      private readonly IWindowRepository windowRepository;
      private readonly IMapper mapper;

      public WindowSaveHandler(IWindowRepository windowRepository, IMapper mapper)
      {
        this.windowRepository = windowRepository ?? throw new ArgumentNullException(nameof(windowRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async Task<WindowDto> Handle(WindowSaveCommand request, CancellationToken cancellationToken)
      {
        var data = mapper.Map<DAL.Entities.Window>(request);
        var res = await windowRepository.AddAsync(data);
        return mapper.Map<WindowDto>(res);

      }
    }

    public class WindowSaveCommandValidator : AbstractValidator<WindowSaveCommand>
    {
      public WindowSaveCommandValidator()
      {
        RuleFor(p => p.Name)
        .NotEmpty().WithMessage("{Name} is required.")
        .NotNull()
        .MaximumLength(150).WithMessage("{Name} must not exceed 150 characters.");

        RuleFor(p => p.Quantity)
           .NotEmpty().WithMessage("{Quantity} is required.")
           .NotNull();
      }
    }

  }
}

