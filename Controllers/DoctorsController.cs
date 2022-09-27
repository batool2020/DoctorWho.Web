using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Models;
using DoctorWho.Web.Services;
using DoctorWho.Web.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorInfoRepository _doctorInfoRepository;
        private readonly IMapper _mapper;
        private readonly IDoctorManager _manager;   

        public DoctorsController(IDoctorInfoRepository doctorInfoRepository, IMapper mapper, IDoctorManager doctormanager)
        {
            
            _doctorInfoRepository = doctorInfoRepository ?? throw new ArgumentNullException(nameof(doctorInfoRepository));
            _mapper = mapper;
            _manager = doctormanager;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            // getting the entity list from the data base
            var doctorEntities = await _doctorInfoRepository.GetDoctorsAsync();
       
           // await _manager.Manage(doctorEntities);
            return Ok(_mapper.Map<IEnumerable<DoctorDto>>(doctorEntities));
            //var result = new List<DoctorDto>(); 
            //// copying the resuts from entity/database to the dto
            //foreach (var doctorEntity in doctorEntities)
            //{
            //    result.Add(new DoctorDto
            //    {
            //        tblDoctorId = doctorEntity.tblDoctorId,
            //        DoctorNumber = doctorEntity.DoctorNumber,
            //        DoctorName = doctorEntity.DoctorName,
            //        BirthDate = doctorEntity.BirthDate,
            //        FirstEpisodeDate = doctorEntity.FirstEpisodeDate,
            //        LastEpisodeDate = doctorEntity.LastEpisodeDate
            //    });
            //} 
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto>> CreateDoctor(
            DoctorDto doctor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            var newDoctor = _mapper.Map<tblDoctor>(doctor);
            await _manager.Manage(newDoctor);
            //adding the doctor 
            await _doctorInfoRepository.InsertDoctorAsync(newDoctor);
            await _doctorInfoRepository.SaveChangesAsync();

            // map the entity back to the dto
            var createdDoctorToReturn = _mapper.Map<Models.DoctorDto>(newDoctor);
            
            //DoctorValidator validator = new DoctorValidator();
            //ValidationResult result = validator.Validate(createdDoctorToReturn);
            //if (!result.IsValid)
            //{
            //    foreach (var failure in result.Errors)
            //    {
            //        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);

            //    }
            //}


            return CreatedAtRoute("GetDoctors",

                new
                {
                    tblDoctorId = createdDoctorToReturn.tblDoctorId,
                    DoctorName = createdDoctorToReturn.DoctorNumber,
                    DoctorNumber = createdDoctorToReturn.DoctorNumber,
                    DoctorBirthDate = createdDoctorToReturn.BirthDate,
                    FirstEpisodeDate = createdDoctorToReturn.FirstEpisodeDate,
                    LastEpisodeDate = createdDoctorToReturn.LastEpisodeDate

                });            
            
        }

        [HttpPut("{doctorid}")]
        public async Task<ActionResult> UpdateDoctor(int doctorid, DoctorUpdateDto doctordto)
        {
            //find the doctor
            var doctorfromdata = await _doctorInfoRepository.GetDoctorByIdAsync(doctorid);
            if(doctorfromdata == null)
            {
                return NotFound();
            }

            var updatedDoctorToReturn = _mapper.Map(doctordto, doctorfromdata);
            await _manager.Manage(updatedDoctorToReturn);

            await _doctorInfoRepository.SaveChangesAsync();

            //DoctorValidator validator = new DoctorValidator();
            //ValidationResult result = validator.Validate(updatedDoctorToReturn);
            //if (!result.IsValid)
            //{
            //    foreach (var failure in result.Errors)
            //    {
            //        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);

            //    }
            //}

            return CreatedAtRoute("",

               new
               {
                   tblDoctorId = updatedDoctorToReturn.tblDoctorId,
                   DoctorName = updatedDoctorToReturn.DoctorName,
                   DoctorNumber = updatedDoctorToReturn.DoctorNumber,
                   DoctorBirthDate = updatedDoctorToReturn.BirthDate,
                   FirstEpisodeDate = updatedDoctorToReturn.FirstEpisodeDate,
                   LastEpisodeDate = updatedDoctorToReturn.LastEpisodeDate

               });

               
        }

        [HttpDelete ("{doctorId}")]
        public async Task<ActionResult> DeleteDoctor(int doctorId)
        {
            var doctor = await _doctorInfoRepository.GetDoctorByIdAsync(doctorId); 
            if(doctor == null)
            {
               return  NotFound();
            }

            _doctorInfoRepository.DeleteDoctor(doctor);

            return Content($" The Doctor with ID : {doctor.tblDoctorId} and Name {doctor.DoctorName} was deleted "); 

        }
    }
}
