using Application.Core;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities
{
  public class Create
  {
    public class Command : IRequest<Result<Unit>>
    {
      public Domain.Activity Activity { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
      }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        _context.Activities.Add(request.Activity);

        var result = await _context.SaveChangesAsync() > 0;
        // SaveChangesAsync returns number of entries written. More than 0 is success

        if (!result) return Result<Unit>.Failure("Falied to create activity");

        return Result<Unit>.Success(Unit.Value);
      }
    }
  }
}