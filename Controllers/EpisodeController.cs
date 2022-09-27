using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Models;
using DoctorWho.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodeController: ControllerBase
    {
        private readonly IEpisodeInfoRepository _episodeInfoRepository;
        private readonly IMapper _mapper;
        private readonly IEpisodeManager _manager;

        public EpisodeController(IEpisodeInfoRepository episodeInfoRepository, IMapper mapper, IEpisodeManager episodemanager)
        {

            _episodeInfoRepository = episodeInfoRepository ?? throw new ArgumentNullException(nameof(episodeInfoRepository));
            _mapper = mapper;
            _manager = episodemanager;

        }
        [HttpGet]
        public async Task<ActionResult<tblEpisode>> GetEpisodeAsync()
        {
            var episodeentities = await _episodeInfoRepository.GetEpisodesAsync();
            return Ok(_mapper.Map<IEnumerable<tblEpisode>>(episodeentities));

        }

        [HttpPost]
        public async Task<ActionResult<EpisodeDto>> CreateEpisode(
           EpisodeDto episode)
        {
            
            var newEpisode = _mapper.Map<tblEpisode>(episode);
            await _manager.Manage(newEpisode);
            //adding the episode 
            await _episodeInfoRepository.InsertEpisdoeAsync(newEpisode);
            await _episodeInfoRepository.SaveChangesAsync();

            // map the entity back to the dto
            var createdEpisodeToReturn = _mapper.Map<Models.EpisodeDto>(newEpisode);



            return CreatedAtRoute("",

                new
                {
                    EpisodeId = createdEpisodeToReturn.tblEpisodeId,
                    EpisodeSeriesNumber = createdEpisodeToReturn.SeriesNumber,
                    EpisodeNumber = createdEpisodeToReturn.EpisodeNumber,
                    EpisodeType = createdEpisodeToReturn.EpisodeType,
                    EpisodeTitle = createdEpisodeToReturn.Title,
                    EpisodeDate = createdEpisodeToReturn.EpisodeDate,
                    EpisodeDoctorId = createdEpisodeToReturn.DoctorId,
                    EpisodeAuthorId = createdEpisodeToReturn.AuthorId,
                    EpisodeNotes = createdEpisodeToReturn.Notes
                    //CompanionsName = createdEpisodeToReturn.Companions,
                    //Enemies = createdEpisodeToReturn.Enemies,

                });
            

        }


    }
}
