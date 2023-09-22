using FluentValidation;

namespace CreditCardChallenge.Web.Models;

public class CardDetailsValidator : AbstractValidator<CardDetails>
{
    public CardDetailsValidator()
    {
        RuleFor(x => x.CardNumber)
            .NotEmpty().WithMessage("Card number is required.")
            .Matches("^[0-9 ]{19}$").WithMessage("Card number must be 16 digits.");
        
        RuleFor(x => x.CardName)
            .NotEmpty().WithMessage("Card name is required.");

        RuleFor(x => x.Month)
            .NotNull().WithMessage("Month is required.");

        RuleFor(x => x.Year)
            .NotNull().WithMessage("Year is required.");

        RuleFor(x => x.Cvv)
            .NotEmpty().WithMessage("CVV is required.")
            .Matches("^[0-9]{3,4}$").WithMessage("CVV must be 3 or 4 digits long.");
    }
}
