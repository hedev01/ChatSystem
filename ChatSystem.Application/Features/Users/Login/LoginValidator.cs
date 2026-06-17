using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ChatSystem.Application.Features.Users.Login
{
    public sealed class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {

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
        }
    }
}
