using System.ComponentModel.DataAnnotations.Schema;

namespace Indigo_Project.Areas.Manage.ViewModels
{
    public class UpdatePostVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
