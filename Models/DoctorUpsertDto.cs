namespace DoctorWho.Web.Models
{
    public class DoctorUpsertDto
    {
        public int tblDoctorId { get; set; }
        // [Required]
        public int DoctorNumber { get; set; }
        // [Required]
        public string DoctorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
    }
}
