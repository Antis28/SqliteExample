
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SqliteExample.Models;
using System.Linq;

namespace SqliteExample.Views
{
    
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            collectionView.ItemsSource = await App.NotesDB.GetNotesAsync();
            base.OnAppearing();
        }

        private async void AddButton_Clicked(object sender, System.EventArgs e)
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