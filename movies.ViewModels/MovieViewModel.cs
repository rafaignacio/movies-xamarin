using System;
using movies.Models;

namespace movies.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        public MovieViewModel()
        {
        }

        private string _image;
        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private DateTime _releaseDate = DateTime.MinValue;
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set => SetProperty(ref _releaseDate, value);
        }

        private string _genres = string.Empty;
        public string Genres
        {
            get => _genres;
            set => SetProperty(ref _genres, value);
        }

        private string _overview = string.Empty;
        public string Overview
        {
            get => _overview;
            set => SetProperty(ref _overview, value);
        }

        public static MovieViewModel FromUpcomingMovieModel(UpcomingMovieModel model)
        {
            var output = new MovieViewModel();
            var genres = new GenreViewModel();

            output.Image = $"https://image.tmdb.org/t/p/w500{model.PosterPath ?? model.BackdropPath}";
            output.Title = model.Title;
            output.ReleaseDate = model.ReleaseDate;
            output.Overview = model.Overview;

            foreach(var item in model.GenreIds)
            {
                output.Genres += $"{genres.GetGenreById(item)}, ";
            }

            if(output.Genres?.Length > 0)
            {
                output.Genres = output.Genres.Substring(0, output.Genres.Length - 2);
            }

            return output;
        }
    }
}
