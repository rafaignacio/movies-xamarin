using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace movies
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await movieViewModel.LoadMovies();
        }

        async void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            if( e.Item.Equals(movieViewModel.Movies.ElementAt(movieViewModel.Movies.Count - 3)) )
            {
                await movieViewModel.LoadMore();
            }
        }
    }
}
