using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPS.Models
{
    public interface IRepository
    {
        IEnumerable<Note> getAllNotes();

        Note getNoteById(int id);
        void addNote(Note note);
        bool updateNote(Note note);
    }
}
