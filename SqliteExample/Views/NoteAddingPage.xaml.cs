
using SqliteExample.Models;
using SqliteExample.Resources;
using SqliteExample.Types;
using System;
using System.Collections.Generic;
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

           // FillPickerMeasurement();
            
        }

        private void FillPickerMeasurement()
        {
            var measurementList = new List<string>();
            measurementList.Add(new ElectricityMeasurement().NameMeasure);
            measurementList.Add(new WaterMeasurement().NameMeasure);
            measurementList.Add(new GasMeasurement().NameMeasure);

            PickerMeasurement.ItemsSource = measurementList;
            PickerMeasurement.SelectedIndex = 0;
        }

        private async void OnSaveButton_Clicked(object sender, System.EventArgs e)
        {
            var note = BindingContext as Note;
            note.Date = DatePickerMeasurement.Date;

            // Выбираем тип измерения
            switch (PickerMeasurement.SelectedIndex)
            {
                case 0: note.Measurement = new ElectricityMeasurement(); break;
                case 1: note.Measurement = new WaterMeasurement(); break;
                case 2: note.Measurement = new GasMeasurement(); break;
                default:
                    throw new Exception("Не могу определить тип измерения");
                    break;
            }

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

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (label != null)
                label.Text = "Вы выбрали " + e.NewDate.ToString("dd/MM/yyyy");
        }
    }
}