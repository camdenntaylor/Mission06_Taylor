using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Taylor.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        
        //sets CategoryId as foreign key
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "You must enter a Title")]
        public string Title { get; set; }

        //user can only enter movie years between 1888 and 2025
        [Range(1888, 2025)]
        [Required(ErrorMessage = "You must enter a Year")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "You must fill out Edited field")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "You must fill out Copied to Plex field")]
        public bool CopiedToPlex {get; set;}
        public string? Notes { get; set; }

    }
}
