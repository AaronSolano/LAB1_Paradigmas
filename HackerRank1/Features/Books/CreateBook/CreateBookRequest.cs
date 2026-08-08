using Newtonsoft.Json;

namespace LibraryService.WebAPI.Features.Books.CreateBook
{
    public class CreateBookRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }

        [JsonProperty("libraryId")]
        public int LibraryId { get; set; }
    }
}
