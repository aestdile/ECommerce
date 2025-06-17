using FluentValidation;

namespace ECommerce.Application.Features.Orders.Commands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ShippingAddress).NotNull();
        RuleFor(x => x.OrderItems).NotEmpty();
        RuleForEach(x => x.OrderItems).ChildRules(items =>
        {
            items.RuleFor(x => x.ProductId).NotEmpty();
            items.RuleFor(x => x.Quantity).GreaterThan(0);
            items.RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
        });
    }
}
