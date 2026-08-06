using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryService.WebAPI.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int LibraryId { get; set; }

        [JsonIgnore]
        public virtual Library? Library { get; set; }
    }
}
