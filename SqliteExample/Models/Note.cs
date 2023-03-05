using System;
using SQLite;
using SqliteExample.Types;

namespace SqliteExample.Models
{
    internal class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Measurement { get; set; }
    }
}
