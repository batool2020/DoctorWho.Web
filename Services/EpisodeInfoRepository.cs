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
            return await _context.Episodes.Include(e => e.Companions).ToListAsync();

        }

        public async Task<tblEpisode> GetEpisodesByIdAsync(int episodeid)
        {
            return await _context.Episodes.Where(e => e.tblEpisodeId == episodeid).Include(e => e.Companions).Include(e=> e.Enemies).FirstOrDefaultAsync();
        }

        public async Task InsertEpisdoeAsync(tblEpisode episode)
        {
            await _context.Episodes.AddAsync(episode);
        }

       
        public async Task InsertCompaniontoEpisode(tblCompanion companion, int episodeId)
        {
            
            var episode = _context.Episodes.Where(e => e.tblEpisodeId == episodeId).Include(e => e.Companions).FirstOrDefault();
          
               episode.Companions.Add(companion);
               await _context.SaveChangesAsync();
        }

        public async Task InsertEnemyToEpisode(tblEnemy enemy, int episodeId)
        {
            var episode = _context.Episodes.Where(e => e.tblEpisodeId == episodeId).Include(e => e.Enemies).FirstOrDefault();
            episode.Enemies.Add(enemy);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> SaveChangesAsync()
        {
            var res = await _context.SaveChangesAsync() >= 0;
            return res;
        }
    }
}
