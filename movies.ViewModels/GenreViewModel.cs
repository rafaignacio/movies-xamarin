using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using movies.Services;
using System.Linq;
using movies.Models;

namespace movies.ViewModels
{
    public class GenreViewModel
    {
        private static IEnumerable<GenreModel> _genres = null;

        static GenreViewModel()
        {
            _genres = GenresService.ListGenres().Results;
        }

        public string GetGenreById(int id)
        {
            return _genres?.FirstOrDefault( g => g.ID == id)?.Name;
        }
    }
}
