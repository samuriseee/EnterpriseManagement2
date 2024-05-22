using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication8.Data
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150, MinimumLength = 20, ErrorMessage = "Title length must be between 20 and 150 characters.")]
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
        public int type { get; set; }
    }
}
