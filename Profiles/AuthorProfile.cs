using AutoMapper;
using DoctorWho.Db;

namespace DoctorWho.Web.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<tblAuthor, Models.AuthorUpdateDto>();
            CreateMap<Models.AuthorUpdateDto, tblAuthor>();
            CreateMap<tblAuthor, Models.AuthorDto>();
            CreateMap<Models.AuthorDto, tblAuthor>();
        }
    }
}
