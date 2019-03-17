using System;
using System.Collections.Generic;
using movies.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace movies.Services
{
    public static class MoviesService
    {
        public static async Task<MovieResult> GetUpcomingMovies(int page = 1)
        {
            using(var client = new HttpClient())
            {
                var output = 
                    await client.GetAsync($"https://api.themoviedb.org/3/movie/upcoming?api_key={ServicesConstants.API_KEY}&page={page}");

                if(output.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await output.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<MovieResult>(content);
                }

                return null;
            }
        }
    }
}
