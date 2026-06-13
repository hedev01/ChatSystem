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
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.firstName)
                .NotEmpty();

            RuleFor(x => x.lastName)
                .NotEmpty();
        }
    }
}
