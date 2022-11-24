using System.ComponentModel.DataAnnotations;

namespace Files.Models
{
    public class FilesModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
