using System.ComponentModel.DataAnnotations;

namespace EntertainmentDorkWebpage.Model
{
    public class MainArticles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public string? ArticleBody { get; set; }
        [Required]
        public bool Published { get; set; } = false;
    }
}
