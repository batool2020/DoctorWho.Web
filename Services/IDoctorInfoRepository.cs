using DoctorWho.Db;

namespace DoctorWho.Web.Services
{
    public interface IDoctorInfoRepository
    {
        Task<IEnumerable<tblDoctor>> GetDoctorsAsync();

       // Task<tblDoctor> GetDoctorAsync(int doctorId);
       Task InsertDoctorAsync(tblDoctor doctor);

        Task<bool> SaveChangesAsync();
        Task<tblDoctor> GetDoctorByIdAsync(int doctorId);


    }
}
