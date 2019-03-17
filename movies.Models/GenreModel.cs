using System;
using Newtonsoft.Json;

namespace movies.Models
{
    public class GenreModel
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
