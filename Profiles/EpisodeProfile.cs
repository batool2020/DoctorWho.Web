using DoctorWho.Db;
using AutoMapper;

namespace DoctorWho.Web.Profiles
{
    public class EpisodeProfile: Profile
    {
        public EpisodeProfile()
        {
            // create a map from the doctor entity to the doctor dto

            CreateMap<tblEpisode, Models.EpisodeDto>();
            CreateMap<Models.EpisodeDto, tblEpisode>();

            CreateMap<tblEnemy, Models.EnemyDto>();
            CreateMap<Models.EnemyDto, tblEnemy>();


            CreateMap<tblCompanion, Models.CompanionDto>();
            CreateMap<Models.CompanionDto, tblCompanion>();

        }
    }
}
