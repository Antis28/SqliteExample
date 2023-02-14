
using SqliteExample.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteExample.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteAddingPage : ContentPage
    {
        public string ItemId {set { LoadNote(value); } }

        

        public NoteAddingPage()
        {
            InitializeComponent();
            BindingContext = new Note();
        }

        private async void OnSaveButton_Clicked(object sender, System.EventArgs e)
        {
            var note = BindingContext as Note;
            note.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.NotesDB.SaveNoteAsync(note);
            }
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButton_Clicked(object sender, System.EventArgs e)
        {
            var note = BindingContext as Note;
            await App.NotesDB.DeleteNoteAsync(note);
            await Shell.Current.GoToAsync("..");
        }
        private async void LoadNote(string value)
        {
            try
            {
                var id = Convert.ToInt32(value);
                var note = await App.NotesDB.GetNoteAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {

            }
        }
    }
}