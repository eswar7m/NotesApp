using Microsoft.AspNetCore.Mvc;
using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly ILogger<NotesController> _logger;
        private readonly ApplicationDbContext _context;

        public NotesController(ILogger<NotesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Note> allNotes = _context.Notes.ToList();
            return View(allNotes);
        }

        public IActionResult CreateEditNote(int? id)
        {
            Note? noteToEdit = null;
            if (id != null)
            {
                noteToEdit = _context.Notes.FirstOrDefault(note => note.Id == id);
            }
            return View(noteToEdit);
        }

        [HttpPost]
        public IActionResult CreateEditNote(Note note)
        {
            if (note.Id == 0)
            {
                _context.Notes.Add(note);
            }
            else
            {
                _context.Notes.Update(note);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNote(int id)
        {
            Note? noteToDelete = _context.Notes.FirstOrDefault(note => note.Id == id);
            if (noteToDelete != null)
            {
                _context.Notes.Remove(noteToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
