using System;
using System.Collections.Generic;
using movies.Models;
using Newtonsoft.Json;

namespace movies.Services
{
    public class MovieResult
    {
        public MovieResult()
        {
        }

        [JsonProperty("results")]
        public List<UpcomingMovieModel> Results { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
