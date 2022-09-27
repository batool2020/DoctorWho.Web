using DoctorWho.Db;
using DoctorWho.Web.Services;
using FluentValidation;

public class EpisodeManager : IEpisodeManager
{
    private readonly IValidator<tblEpisode> _validator;
    public EpisodeManager(IValidator<tblEpisode> validator)
    {
        this._validator = validator;
    }

    public async Task Manage(tblEpisode episode)
    {
        await _validator.ValidateAndThrowAsync(episode);
    }
}