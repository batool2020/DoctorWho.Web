using DoctorWho.Db;

namespace DoctorWho.Web.Services
{
    public interface IDoctorInfoRepository
    {
        Task<IEnumerable<tblDoctor>> GetDoctorsAsync();

       // Task<tblDoctor> GetDoctorAsync(int doctorId);


    }
}
