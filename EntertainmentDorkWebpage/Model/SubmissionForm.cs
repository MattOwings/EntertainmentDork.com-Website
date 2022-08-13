using System.ComponentModel.DataAnnotations;

namespace EntertainmentDorkWebpage.Model
{
    public class SubmissionForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? DiscordName { get; set; }
        public string? InstagramName { get; set; }
        [Required]
        public string? Interests { get; set; }
        public string? LinkToPastWork { get; set; }
        public bool Verified { get; set; } = false;
    }
}
