﻿using FastEndpoints;
using FluentValidation;

namespace Queueomatic.Server.Endpoints.SignUp;

public class SignUpValidator : Validator<SignUpRequest>
{
    public SignUpValidator()
    {
        RuleFor(x => x.Signup.Password)
            .NotEmpty().WithMessage("A password is required!")
            .MinimumLength(10).WithMessage("Please provide a longer password")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");


    }
}