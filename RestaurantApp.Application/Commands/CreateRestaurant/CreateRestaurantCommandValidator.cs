using FluentValidation;

namespace RestaurantApp.Application.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> _validCategories = ["Indian", "Mexican", "American", "Italian"];

    public CreateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name).Length(3, 100);
        RuleFor(x => x.Description).Length(3, 200);

        RuleFor(x => x.ContactEmail)
            .EmailAddress()
            .WithMessage("Please enter a valid email address");
        
        RuleFor(x => x.Category)
            .Must(x => _validCategories.Contains(x))
            .WithMessage(x => $"Category {x} is invalid");
    }
}