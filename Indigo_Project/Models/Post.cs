using System.ComponentModel.DataAnnotations.Schema;

namespace Indigo_Project.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
