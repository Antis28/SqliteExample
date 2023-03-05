using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SqliteExample.Models;

namespace SqliteExample.Data
{
    internal class NoteDB
    {
        readonly SQLiteAsyncConnection db;
        public NoteDB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<Note>().Wait();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return db.Table<Note>().ToListAsync();
        }
        public Task<List<Note>> GetNotesSelectElectroAsync()
        {
            return db.Table<Note>().OrderBy((x) => x.Date).ToListAsync();
        }
        public Task<Note> GetNoteAsync(int id)
        {
            return db.Table<Note>().
                Where(x => x.Id == id).
                FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return db.UpdateAsync(note);
            }
            else
            {
                return db.InsertAsync(note);
            }
        }
        public Task<int> DeleteNoteAsync(Note note)
        {
            return db.DeleteAsync(note);
        }
    }
}
