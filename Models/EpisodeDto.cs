﻿using DoctorWho.Db;

namespace DoctorWho.Web.Models
{
    public class EpisodeDto
    {
        public int tblEpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public int AuthorId { get; set; }
        public int DoctorId { get; set; }
        public string Notes { get; set; }

        public List<tblEnemy> Enemies { get; set; }
        public List<tblCompanion> Companions { get; set; }
        

    }
}
