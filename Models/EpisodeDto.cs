using DoctorWho.Db;

namespace DoctorWho.Web.Models
{
    public class EpisodeDto
    {
        public int tblEpisodeId { get; set; }
        public string SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public int AuthorId { get; set; }
        public int DoctorId { get; set; }
        public string Notes { get; set; }

        //public List<Enemy> Enemies { get; set; }
        //public List<Controller> Companions { get; set; }
        

    }
}
