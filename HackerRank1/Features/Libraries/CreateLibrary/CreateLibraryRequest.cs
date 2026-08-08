using Newtonsoft.Json;

namespace LibraryService.WebAPI.Features.Libraries.CreateLibrary
{
    public class CreateLibraryRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }
    }
}
