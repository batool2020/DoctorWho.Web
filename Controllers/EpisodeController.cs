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

                });
            

        }


        [HttpPut("{episodeid}/Companion")]
        public async Task<ActionResult<EpisodeDto>> AddCompaniontoEpisode(
          CompanionDto companion,  int episodeid)
        {
            // find the episode
            var EpisodeById = await _episodeInfoRepository.GetEpisodesByIdAsync(episodeid);
            if (EpisodeById == null)
            {
                return NotFound();
            }

            // map the companiondto to the table
            var newCompanion = _mapper.Map<tblCompanion>(companion);


            await _episodeInfoRepository.InsertCompaniontoEpisode(newCompanion, EpisodeById.tblEpisodeId);

            //map the episode back to the dto
            var updatedEpisode = _mapper.Map<Models.EpisodeDto>(await _episodeInfoRepository.GetEpisodesByIdAsync(episodeid)); // read the episode from database


            return CreatedAtRoute("",

                new
                {
                    EpisodeSeriesNumber = updatedEpisode.SeriesNumber,
                    EpisodeNumber = updatedEpisode.EpisodeNumber,
                    EpisodeType = updatedEpisode.EpisodeType,
                    EpisodeTitle = updatedEpisode.Title,
                    EpisodeDate = updatedEpisode.EpisodeDate,
                    EpisodeDoctorId = updatedEpisode.DoctorId,
                    EpisodeAuthorId = updatedEpisode.AuthorId,
                    EpisodeNotes = updatedEpisode.Notes,
                    EpisodeCompanion = updatedEpisode.Companions
                    

                });


        }


        [HttpPut("{episodeid}/Enemy")]
        public async Task<ActionResult<EpisodeDto>> AddEnemytoEpisode(
          EnemyDto enemy, int episodeid)
        {
            // find the episode
            var EpisodeById = await _episodeInfoRepository.GetEpisodesByIdAsync(episodeid);
            if (EpisodeById == null)
            {
                return NotFound();
            }

            // map the companiondto to the table
            var newEnemy = _mapper.Map<tblEnemy>(enemy);


            await _episodeInfoRepository.InsertEnemyToEpisode(newEnemy, EpisodeById.tblEpisodeId);

            //map the episode back to the dto
            var updatedEpisode = _mapper.Map<Models.EpisodeDto>(await _episodeInfoRepository.GetEpisodesByIdAsync(episodeid)); // read the episode from database


            return CreatedAtRoute("",

                new
                {
                    EpisodeSeriesNumber = updatedEpisode.SeriesNumber,
                    EpisodeNumber = updatedEpisode.EpisodeNumber,
                    EpisodeType = updatedEpisode.EpisodeType,
                    EpisodeTitle = updatedEpisode.Title,
                    EpisodeDate = updatedEpisode.EpisodeDate,
                    EpisodeDoctorId = updatedEpisode.DoctorId,
                    EpisodeAuthorId = updatedEpisode.AuthorId,
                    EpisodeNotes = updatedEpisode.Notes,
                    EpisodeCompanion = updatedEpisode.Companions,
                    EpisodeEnemy = updatedEpisode.Enemies


                });


        }





    }
}
