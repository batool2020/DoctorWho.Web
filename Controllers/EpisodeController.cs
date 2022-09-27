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


    }
}
