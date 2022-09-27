using DoctorWho.Db;
using FluentValidation;

namespace DoctorWho.Web.Services
{
    public class DoctorManager: IDoctorManager
    {
        private readonly IValidator<tblDoctor> _validator;  
        public DoctorManager(IValidator<tblDoctor> validator)
        {
            this._validator = validator;
        }

        public async Task Manage(tblDoctor doctor)
        {
            await _validator.ValidateAndThrowAsync(doctor);
        }
    }
}
