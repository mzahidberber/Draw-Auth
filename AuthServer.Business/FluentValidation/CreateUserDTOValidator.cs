using AuthServer.Core.DTOs;
using FluentValidation;

namespace AuthServer.Business.FluentValidation
{
    public class CreateUserDTOValidator:AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is wrong");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");


        }
    }
}
