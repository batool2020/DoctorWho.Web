using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Models;
using DoctorWho.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
      

            private readonly IAuthorRepository _authorInfoRepository;
            private readonly IMapper _mapper;
            private readonly IAuthorManager _manager;

            public AuthorsController(IAuthorRepository authorInfoRepository, IMapper mapper, IAuthorManager authormanager)
            {

            _authorInfoRepository = authorInfoRepository ?? throw new ArgumentNullException(nameof(authorInfoRepository));
                _mapper = mapper;
                _manager = authormanager;

            }


            [HttpGet]
         public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthorAsync()
        {
            // getting the entity list from the data base
            var authorentities = await _authorInfoRepository.GetAuthorAsync();  

            // await _manager.Manage(doctorEntities);
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorentities));


        }

        //Update API
        [HttpPut("{authorId}/update")]
        public async Task<ActionResult> UpdateAuthor(int authorId, AuthorUpdateDto authordto)
        {
            //find the author
            var authorentity = await _authorInfoRepository.GetAuthorByIdAsync(authorId);
            if (authorentity == null)
            {
                return NotFound();
            }
            var updatedAuthorToReturn = _mapper.Map(authordto, authorentity);
            await _manager.Manage(updatedAuthorToReturn);

            await _authorInfoRepository.SaveChangesAsync();

            return CreatedAtRoute("",

               new
               {
                  tblAuthorId = updatedAuthorToReturn.tblAuthorId,
                  AuthorName = updatedAuthorToReturn.AuthorName

               });
        }



    }
}
