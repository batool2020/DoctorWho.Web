namespace DoctorWho.Web.Models
{
    public class DoctorUpsertUpdateDto
    {
        // [Required]
        public int DoctorNumber { get; set; }
        // [Required]
        public string DoctorName { get; set; }
        public DateTime? BirthDate { get; set; }

        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
    }
}
