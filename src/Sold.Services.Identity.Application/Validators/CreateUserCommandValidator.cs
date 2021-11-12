using FluentValidation;
using Sold.Services.Identity.Application.Commands;

namespace Sold.Services.Identity.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.User).NotNull();
            RuleFor(x => x.User.Mail).EmailAddress();
            RuleFor(x => x.User.Name).NotEmpty();
            RuleFor(x => x.User.Phone).NotNull();
        }
    }
}