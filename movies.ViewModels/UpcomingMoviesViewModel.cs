using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using movies.Models;
using System.Linq;
using movies.Services;

namespace movies.ViewModels
{
    public class UpcomingMoviesViewModel : BaseViewModel
    {

        private int _current_page = 1;
        public int CurrentPage
        {
            get => _current_page;
            set => SetProperty(ref _current_page, value);
        }

        private int _total_pages = 0;

        private ObservableCollection<MovieViewModel> _movies = 
            new ObservableCollection<MovieViewModel>();
        public ObservableCollection<MovieViewModel> Movies
        {
            get => _movies;
            set => SetProperty(ref _movies, value);
        }

        private bool _is_loading = false;
        public bool IsLoading
        {
            get => _is_loading;
            set => SetProperty(ref _is_loading, value);
        }

        public async Task LoadMovies()
        {
            try
            {
                IsLoading = true;

                var result = await MoviesService.GetUpcomingMovies(CurrentPage);

                _total_pages = result.TotalPages;

                foreach (var i in result.Results)
                {
                    Movies.Add(item: MovieViewModel.FromUpcomingMovieModel(i));
                }

                OnPropertyChanged(nameof(Movies));
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task LoadMore()
        {
            if (CurrentPage > _total_pages) return;

            CurrentPage++;
            await LoadMovies();
        }
    }
}
