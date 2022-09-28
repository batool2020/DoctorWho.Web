using DoctorWho.Db;
using FluentValidation;

namespace DoctorWho.Web.Services
{
    public class AuthorManager: IAuthorManager
    {

            private readonly IValidator<tblAuthor> _validator;
            public AuthorManager(IValidator<tblAuthor> validator)
            {
                this._validator = validator;
            }

            public async Task Manage(tblAuthor author)
            {
                await _validator.ValidateAndThrowAsync(author);
            }
        }
}
