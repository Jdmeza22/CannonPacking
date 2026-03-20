using CannonPacking.Application.Dtos;
using FluentValidation;

public class TowelValidator : AbstractValidator<CreateTowelRequest>
{
    public TowelValidator()
    {
        RuleFor(x => x.ItemCode)
            .NotEmpty().WithMessage("El código del item es obligatorio")
            .MaximumLength(50);

        RuleFor(x => x.ProductCode)
            .NotEmpty().WithMessage("El código del producto es obligatorio")
            .MaximumLength(50);
    }
}