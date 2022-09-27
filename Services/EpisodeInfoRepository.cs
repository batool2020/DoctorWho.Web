using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DoctorWho.Web.Services
{
    public class EpisodeInfoRepository : IEpisodeInfoRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public EpisodeInfoRepository(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }


        public async Task<IEnumerable<tblEpisode>> GetEpisodesAsync()
        {
            return await _context.Episodes.ToListAsync();
           }

        public async Task InsertEpisdoeAsync(tblEpisode episode)
        {
            await _context.Episodes.AddAsync(episode);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
