using DoctorWho.Web.Models;
using DoctorWho.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorInfoRepository _doctorInfoRepository;    
        public DoctorsController(IDoctorInfoRepository doctorInfoRepository)
        {
            _doctorInfoRepository = doctorInfoRepository ?? throw new ArgumentNullException(nameof(doctorInfoRepository));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            // getting the entity list from the data base
            var doctorEntities = await _doctorInfoRepository.GetDoctorsAsync(); 
            var result = new List<DoctorDto>(); 
            // copying the resuts from entity/database to the dto
            foreach (var doctorEntity in doctorEntities)
            {
                result.Add(new DoctorDto
                {
                    tblDoctorId = doctorEntity.tblDoctorId,
                    DoctorNumber = doctorEntity.DoctorNumber,
                    DoctorName = doctorEntity.DoctorName,
                    BirthDate = doctorEntity.BirthDate,
                    FirstEpisodeDate = doctorEntity.FirstEpisodeDate,
                    LastEpisodeDate = doctorEntity.LastEpisodeDate
                });
            }   
            
            return Ok(result);  
        }
    }
}
