using EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Validation
{
    public class CreateTitleValidator : AbstractValidator<CreateTitleCommandRequest>
    {
        public CreateTitleValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name field should not be empty")
                                .NotNull().WithMessage("Name field should not be null");
            RuleFor(c => c.ChannelId).NotEmpty().WithMessage("channel id field should not be empty")
                                     .NotNull().WithMessage("channel id field should not be null");
        } 
    }
}
