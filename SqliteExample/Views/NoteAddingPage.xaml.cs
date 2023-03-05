
using SqliteExample.Models;
using SqliteExample.Resources;
using SqliteExample.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteExample.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteAddingPage : ContentPage
    {
        public string ItemId {set { LoadNote(value); } }


        public  NoteAddingPage()
        {
            FocusEditor();
            InitializeComponent();
            BindingContext = new Note();

            FillPickerMeasurement();
            DatePickerMeasurement.Date = DateTime.Now;
        }

        private async void FocusEditor()
        {
            await Task.Run(async () =>
            {
                await Task.Delay(100);
                Device.BeginInvokeOnMainThread(() =>
                {
                    MeasuremenValue.Focus();
                });
            });
        }

        private void FillPickerMeasurement()
        {
            var measurementList = new List<string>();
            measurementList.Add(new ElectricityMeasurement());
            measurementList.Add(new WaterMeasurement());
            measurementList.Add(new GasMeasurement());

            PickerMeasurement.ItemsSource = measurementList;
            PickerMeasurement.SelectedIndex = 0;            
        }

        private async void OnSaveButton_Clicked(object sender, System.EventArgs e)
        {
            var note = BindingContext as Note;
            var nowDateTime = DateTime.Now;
            note.Date = DatePickerMeasurement.Date.AddHours(nowDateTime.Hour).AddMinutes(nowDateTime.Minute);

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
            else
            {
               await DisplayAlert("Уведомление", "Не могу сохранить!\nНе указано значение для показания счетчика", "ОK");
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
            //if (label != null)
            //    label.Text = "Вы выбрали " + e.NewDate.ToString("dd/MM/yyyy");
        }
    }
}