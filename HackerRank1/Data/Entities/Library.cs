using System.ComponentModel.DataAnnotations;

namespace LibraryService.WebAPI.Data.Entities
{
    public class Library
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }
}
