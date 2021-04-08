using System.Collections.Generic;
using System.Text.Json.Serialization;
using RestWithAspNET.Hypermedia;
using RestWithAspNET.Hypermedia.Abstract;

namespace RestWithAspNET.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        
        [JsonPropertyName("address")]
        public string Address { get; set; }
        
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}