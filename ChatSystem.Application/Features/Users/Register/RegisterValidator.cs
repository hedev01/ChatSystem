using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ChatSystem.Application.Features.Users.Register
{
    public sealed class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.userName)
                .NotEmpty()
                .WithMessage("Please enter your username.")
                .MinimumLength(3)
                .WithMessage("Username must contain at least 3 characters.")
                .MaximumLength(50)
                .WithMessage("Username cannot be longer than 50 characters.");

            RuleFor(x => x.email)
                .NotEmpty()
                .WithMessage("Please enter your email address.")
                .EmailAddress()
                .WithMessage("The email address format is invalid.");

            RuleFor(x => x.password)
                .NotEmpty()
                .WithMessage("Please enter your password.")
                .MinimumLength(8)
                .WithMessage("Password must contain at least 8 characters.");

            RuleFor(x => x.firstName)
                .NotEmpty()
                .WithMessage("Please enter your first name.");

            RuleFor(x => x.lastName)
                .NotEmpty()
                .WithMessage("Please enter your last name.");
        }
    }
}
