using System;
using Newtonsoft.Json;

namespace movies.Models
{
    public class UpcomingMovieModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("genre_ids")]
        public int[] GenreIds { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
    }
}
