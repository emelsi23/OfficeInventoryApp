using FluentValidation;
using OfficeInventory.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeInventory.Application.Validators
{
    public class MaintenanceTaskDtoValidator : AbstractValidator<MaintenanceTaskDto>
    {
        public MaintenanceTaskDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(100).WithMessage("Description must be at most 100 characters.");
        }

    }
}
