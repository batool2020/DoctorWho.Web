using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Web.Services
{
    public class DoctorInfoRepository : IDoctorInfoRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public DoctorInfoRepository(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }


        public async Task<IEnumerable<tblDoctor>> GetDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();

        }
    }
}
