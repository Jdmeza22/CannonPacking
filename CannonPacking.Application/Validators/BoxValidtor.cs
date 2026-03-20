using CannonPacking.Application.Dtos;
using FluentValidation;

public class BoxValidator : AbstractValidator<CreateBoxRequest>
{
    public BoxValidator()
    {
        RuleFor(x => x.BoxCode)
            .NotEmpty().WithMessage("El código de la caja es obligatorio");

        RuleFor(x => x.ProductCode)
            .NotEmpty().WithMessage("El código del producto es obligatorio");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("La capacidad debe ser mayor a cero");
    }
}