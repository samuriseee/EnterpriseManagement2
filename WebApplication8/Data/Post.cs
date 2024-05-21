using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication8.Data
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
        public int type { get; set; }
    }
}
