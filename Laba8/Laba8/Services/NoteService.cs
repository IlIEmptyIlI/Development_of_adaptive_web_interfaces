using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Laba8.Models;

namespace NoteApp.Services
{
    public class NoteService : INoteService
    {
        private static List<Note> _notes = new List<Note>();
       

        public NoteService()
        {
            if (_notes.Count == 0)
            {
                _notes = new List<Note>
            {
                new Note { Id = 1, Title = "Note 1", Content = "Content 1" },
                new Note { Id = 2, Title = "Note 2", Content = "Content 2" },
            };
            }
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            return _notes;
        }

        public async Task<Note> CreateNote(Note note)
        {
            _notes.Add(note);
            return note;
        }

        public async Task<Note> UpdateNote(Note note)
        {
            var existingNote = _notes.Find(n => n.Id == note.Id);
            if (existingNote != null)
            {
                existingNote.Title = note.Title;
                existingNote.Content = note.Content;
            }
            return existingNote;
        }

        public async Task<bool> DeleteNote(int id)
        {
            var noteToRemove = _notes.Find(n => n.Id == id);
            if (noteToRemove != null)
            {
                _notes.Remove(noteToRemove);
                return true;
            }
            return false;
        }
    }
}
