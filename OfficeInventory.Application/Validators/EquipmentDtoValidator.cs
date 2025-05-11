using FluentValidation;
using OfficeInventory.Application.DTOs;


namespace OfficeInventory.Application.Validators
{
    public class EquipmentDtoValidator : AbstractValidator<EquipmentDto>
    {
        public EquipmentDtoValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand is required.")
                .MaximumLength(50).WithMessage("Brand must be at most 50 characters.");

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Model is required.")
                .MaximumLength(50).WithMessage("Model must be at most 50 characters.");

            RuleFor(x => x.EquipmentTypeId)
                .GreaterThan(0).WithMessage("EquipmentTypeId must be greater than 0.");

            RuleFor(x => x.PurchaseDate)
                .NotEmpty().WithMessage("PurchaseDate is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("PurchaseDate cannot be in the future.");

            RuleFor(x => x.SerialNumber)
                .MaximumLength(16).WithMessage("SerialNumber must be at most 16 characters.")
                .When(x => !string.IsNullOrEmpty(x.SerialNumber));
        }
    }
}
