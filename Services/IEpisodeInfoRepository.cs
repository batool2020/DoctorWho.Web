using DoctorWho.Db;

namespace DoctorWho.Web.Services
{
    public interface IEpisodeInfoRepository
    {
        Task<IEnumerable<tblEpisode>> GetEpisodesAsync();
        Task InsertEpisdoeAsync(tblEpisode episode);
        Task<tblEpisode> GetEpisodesByIdAsync(int episodeId);
        Task InsertCompaniontoEpisode(tblCompanion companion, int episodeid);
        Task InsertEnemyToEpisode(tblEnemy enemy, int episodeId);
        Task<bool> SaveChangesAsync();
    }
}
