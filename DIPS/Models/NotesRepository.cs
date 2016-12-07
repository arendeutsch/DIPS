using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIPS.Models
{
    public class NotesRepository : IRepository
    {
        private ApplicationDbContext db;

        public NotesRepository()
        {
            db = new ApplicationDbContext();            
        }

        /// <summary>
        /// add note to database
        /// </summary>
        /// <param name="note"></param>
        public void addNote(Note note)
        {     
            db.Notes.Add(note);
            db.SaveChanges();
        }

        /// <summary>
        /// fetches all notes from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Note> getAllNotes()
        {           
            return db.Notes.ToList();
        }

        /// <summary>
        /// fetches a note from databse given note's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Note getNoteById(int id)
        {            
            return db.Notes.FirstOrDefault(n => n.Id == id);
        }

        /// <summary>
        /// update note and saves it to the database
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public bool updateNote(Note note)
        {  
            try
            {
                /*var newNote = getNoteById(id);
                newNote.Name = note.Name;
                newNote.Text = note.Text;*/
                db.Entry(note).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }      

        }
    }
}