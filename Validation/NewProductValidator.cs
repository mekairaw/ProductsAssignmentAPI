using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAssignmentAPI.Domain.Resources;
using FluentValidation;

namespace ProductsAssignmentAPI.Validation
{
    public class NewProductValidator : AbstractValidator<NewProductResource>
    {
        public NewProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty();
            RuleFor(p => p.IsActive)
                .NotNull();
            RuleFor(p => p.ProductTypeId)
                .NotNull();
            RuleFor(p => p.Price)
                .GreaterThan(0);
        }
    }
}
