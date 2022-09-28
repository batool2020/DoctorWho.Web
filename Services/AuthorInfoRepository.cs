using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Web.Services
{
    public class AuthorInfoRepository : IAuthorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public AuthorInfoRepository(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<tblAuthor>> GetAuthorAsync()
        {
            return await _context.Authors.ToListAsync();

        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<tblAuthor> GetAuthorByIdAsync(int authoId)
        {
            return await _context.Authors.FindAsync(authoId);
        }

    }
}
