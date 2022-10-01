using DoctorWho.Db;
using FluentValidation;
using System.Linq;

namespace episodeWho.Web.Validators
{
    public class EpisodeValidator: AbstractValidator<tblEpisode>
    {
        public EpisodeValidator()
        {
            RuleFor(episode => episode.AuthorId).NotNull().NotEmpty().WithMessage("Author Id is requiered");
            RuleFor(episode => episode.DoctorId).NotNull().NotEmpty().WithMessage("Doctor Id is requiered");
            RuleFor(episode => episode.EpisodeNumber).GreaterThan(0).WithMessage(" episode Number should be Greater than 0");
            
            // RuleFor(episode => episode.SeriesNumber).Length(10).WithMessage(" Series Number should be max 10 chars long ");

        }
    }
}
