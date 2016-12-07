using DIPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DIPS.Controllers
{
    public class NotesController : ApiController
    {
        private IRepository repository;

        public NotesController(IRepository repository)
        {
            this.repository = repository;
        }

        public NotesController()
        {

            repository = new NotesRepository();
        }
        /// <summary>
        /// Use this method to get all notes from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Note> Get()
        {
            return repository.getAllNotes();
        }

        /// <summary>
        /// Use this method to get a specific note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Note))]
        public IHttpActionResult Get(int id)
        {
            var note =  repository.getNoteById(id);

            if (note != null)
            {                
                return Ok(note);
            }
            else
            {                
                return NotFound();
            }
        }

        /// <summary>
        /// Use this method to add a new note 
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        [ResponseType(typeof(Note))]
        public IHttpActionResult Post(Note note)
        { 
            if (ModelState.IsValid)
            {
                repository.addNote(note);
                return CreatedAtRoute("DefaultApi", new {id = note.Id }, note);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Use this method to update a note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [ResponseType(typeof(Note))]
        public IHttpActionResult Put(int id, Note note)
        {

            Note oldNote = repository.getNoteById(id);
            oldNote.Name = note.Name;
            oldNote.Text = note.Text; 

            if (ModelState.IsValid && id == note.Id)
            {
                bool ok = repository.updateNote(oldNote);
                if (!ok)
                {                    
                    return BadRequest();
                }
                else
                {                    
                    return Ok(ok);
                }
            }
            else
            {                
                return NotFound();
            }   
        }

    }
}
