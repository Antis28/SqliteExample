using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SqliteExample.Data;
using System.IO;

namespace SqliteExample
{
    public partial class App : Application
    {
        private static NoteDB notesDB;

        internal static NoteDB NotesDB {
            get { 
                if (notesDB == null)
                {
                    notesDB = new NoteDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "NotesDataBase.db3"));
                }
                return notesDB;
            }
            set => notesDB = value; 
        }

        public App()
        {
            InitializeComponent();

           MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
