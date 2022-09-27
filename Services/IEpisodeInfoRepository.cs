using DoctorWho.Db;

namespace DoctorWho.Web.Services
{
    public interface IEpisodeInfoRepository
    {
        Task<IEnumerable<tblEpisode>> GetEpisodesAsync();

        // Task<tblDoctor> GetDoctorAsync(int doctorId);
        Task InsertEpisdoeAsync(tblEpisode episode);

        Task<bool> SaveChangesAsync();
    }
}
