using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace FluentValidationExample.Models.Validator
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Account).NotNull().WithMessage("名稱不可為空");
            RuleFor(x => x).Custom((x, c) =>
            {
                if (x.Password == "" || x.Password == null)
                {
                    c.AddFailure("Password", "密碼不可為空");
                }
            });
        }

    }
}
