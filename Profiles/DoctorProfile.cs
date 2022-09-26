using AutoMapper;
using DoctorWho.Db;

namespace DoctorWho.Web.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            // create a map from the doctor entity to the doctor dto

            CreateMap<tblDoctor, Models.DoctorDto>();


        }
    }
}
