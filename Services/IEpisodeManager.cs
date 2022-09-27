using DoctorWho.Db;

namespace DoctorWho.Web.Services
{
    public interface IEpisodeManager
    {
        public Task Manage(tblEpisode episode);
    }
}
