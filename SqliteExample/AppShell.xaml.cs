using SqliteExample.Views;
using Xamarin.Forms;

namespace SqliteExample
{

    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteAddingPage), typeof(NoteAddingPage));
            Routing.RegisterRoute(nameof(NotesPage), typeof(NotesPage));
        }
    }
}