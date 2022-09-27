using DoctorWho.Db;
using DoctorWho.Web.Models;
using FluentValidation;
using System.Numerics;

namespace DoctorWho.Web.Validators
{
    public class DoctorValidator: AbstractValidator<tblDoctor>
    {
        public DoctorValidator()
        {
            RuleFor(doctor => doctor.DoctorNumber).NotNull().NotEmpty().WithMessage("Doctor Number is requiered");
            RuleFor(doctor => doctor.DoctorName).NotNull().NotEmpty().WithMessage(" Doctor Name is requiered");
            RuleFor(doctor => doctor.LastEpisodeDate).Null().When(doctor => ! doctor.FirstEpisodeDate.HasValue).WithMessage("Can't accept Episode Last Date with no Value to Episode first Date ");
            ;
            RuleFor(doctor => doctor.FirstEpisodeDate).LessThan(doctor => doctor.LastEpisodeDate).WithMessage("Episode first Date should be less than Episode last date");


        }
    }
}
