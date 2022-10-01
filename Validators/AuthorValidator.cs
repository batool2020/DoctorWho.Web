using DoctorWho.Db;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class AuthorValidator : AbstractValidator<tblAuthor>
    {

        public AuthorValidator()
        {
            RuleFor(author => author.AuthorName).NotNull().NotEmpty();

        }

    }
}
