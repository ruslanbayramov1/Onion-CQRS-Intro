using FluentValidation;
using OnionAPI.Application.Features.Commands.CreateProduct;
using OnionAPI.Application.Settings;

namespace OnionAPI.Application.Validators.Products;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(ProductSetting.MinNameLength)
            .WithMessage($"Product name can not be less than {ProductSetting.MinNameLength} characters")
            .MaximumLength(ProductSetting.MaxNameLength)
            .WithMessage($"Product name can not be more than {ProductSetting.MaxNameLength} characters");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(ProductSetting.MinPrice)
            .WithMessage($"Price can not be less than ${ProductSetting.MinPrice}");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(ProductSetting.MinStock)
            .WithMessage($"Stock can not be less than {ProductSetting.MinStock}");
    }
}
