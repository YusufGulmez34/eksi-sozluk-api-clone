using EksiSozlukAPI.Application.Features.Commands.User.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Validation
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Nickname).NotNull().WithMessage("Nickname field should not be null")
                                    .NotEmpty().WithMessage("Nickname fiels should not be empty");
            RuleFor(u => u.Password).NotNull().WithMessage("Password field should not be null")
                                    .NotEmpty().WithMessage("Password fiels should not be empty");
            RuleFor(u => u.Email).NotNull().WithMessage("Email field should not be null")
                                 .NotEmpty().WithMessage("Email fiels should not be empty");

        }
    }
}
