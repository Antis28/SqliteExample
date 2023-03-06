
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SqliteExample.Models;
using System.Linq;
using SqliteExample.Types;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SqliteExample.Views
{
    [QueryProperty(nameof(ShowedMeasurement), nameof(ShowedMeasurement))]
    public partial class NotesPage : ContentPage
    {
        List<Note> notes;

        public string ShowedMeasurement { set; get; }

        public NotesPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            var myTask = App.NotesDB.GetNotesAsync();

            notes = await myTask;

            if(string.IsNullOrEmpty(ShowedMeasurement))
                ShowedMeasurement = new ElectricityMeasurement();
            SortDataByAsync(ShowedMeasurement);

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

        private void SortByElectricityButton_Clicked(object sender, System.EventArgs e)
        {
            ShowedMeasurement = new ElectricityMeasurement();
            SortDataByAsync(ShowedMeasurement);
        }

        private void SortDataByAsync(MeasurementType type)
        {

            var source = from note in notes
                         where note.Measurement == type
                         orderby note.Date descending
                         select note;

            var listData = source.ToList<Note>();

            for (int i = 0; i < listData.Count - 1; i++)
            {
                var itemValue = System.Convert.ToInt32(listData[i].Text);
                var nextItemValue = System.Convert.ToInt32(listData[i + 1].Text);
                listData[i].Expenditure = itemValue - nextItemValue;
            }
            collectionView.ItemsSource = listData;
        }

        private void SortByWaterButton_Clicked(object sender, System.EventArgs e)
        {
            ShowedMeasurement = new WaterMeasurement();
            SortDataByAsync(ShowedMeasurement);
        }

        private void SortByGasButton_Clicked(object sender, System.EventArgs e)
        {
            ShowedMeasurement = new GasMeasurement();
            SortDataByAsync(ShowedMeasurement);
        }
    }
}