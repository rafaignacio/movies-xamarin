using System;
using System.Collections.Generic;
using movies.Models;
using Newtonsoft.Json;

namespace movies.Services
{
    public class GenreResult
    {
        [JsonProperty("genres")]
        public IEnumerable<GenreModel> Results { get; set; }
    }
}
