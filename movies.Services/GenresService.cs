using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace movies.Services
{
    public static class GenresService
    {
        public static GenreResult ListGenres()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"https://api.themoviedb.org/3/genre/movie/list?api_key={ServicesConstants.API_KEY}")
                    .GetAwaiter().GetResult();


                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    return JsonConvert.DeserializeObject<GenreResult>(content);
                }

                return null;
            }
        }
    }
}
