using SqliteExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SqliteExample.Types;

namespace SqliteExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElectricityPage : ContentPage
    {
        public ElectricityPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var data = await App.NotesDB.GetNotesAsync();
            var source = from note in data
                         where note.Measurement == new ElectricityMeasurement()
                         orderby note.Date descending
                         select note;
            collectionView.ItemsSource = source;
            base.OnAppearing();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NoteAddingPage));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                var note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync(
                    $"{nameof(NoteAddingPage)}?{nameof(NoteAddingPage.ItemId)}={note.Id.ToString()}");
            }
        }
    }
}