using Newtonsoft.Json;

namespace LibraryService.WebAPI.Features.Libraries.UpdateLibrary
{
    public class UpdateLibraryRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }
    }
}
