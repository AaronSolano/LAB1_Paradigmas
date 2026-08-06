using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.Text.Json.Serialization;
=======
>>>>>>> origin/main

namespace LibraryService.WebAPI.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

<<<<<<< HEAD
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int LibraryId { get; set; }

        [JsonIgnore]
        public virtual Library? Library { get; set; }
=======
        public string Name { get; set; }

        public string Category { get; set; }

        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }
>>>>>>> origin/main
    }
}
