using System.Collections.Generic;
using System.Threading.Tasks;
using Laba8.Models;

namespace NoteApp.Services
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<Note> CreateNote(Note note);
        Task<Note> UpdateNote(Note note);
        Task<bool> DeleteNote(int id);
    }
}
