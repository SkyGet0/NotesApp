using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string Title {get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Content { get; set; } = string.Empty;

        public bool IsImportant { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}