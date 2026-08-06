using System.ComponentModel.DataAnnotations;

namespace LibraryService.WebAPI.Domain.Entities
{
    public class Library
    {
        [Key]
        public int Id { get; set; }

<<<<<<< HEAD
        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
=======
        public string Name { get; set; }

        public string Location { get; set; }
>>>>>>> origin/main
    }
}
