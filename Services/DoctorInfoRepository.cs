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

        public async Task InsertDoctorAsync(tblDoctor doctor)
        {
            // we need to call save changes to save data to database
            await _context.Doctors.AddAsync(doctor);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);    
        }


        public async Task<tblDoctor> GetDoctorByIdAsync(int doctorId)
        {
            return await _context.Doctors.FindAsync(doctorId);
        }

       public void DeleteDoctor(tblDoctor doctor)
        {
            _context.Remove(doctor);
        }


    }
}
