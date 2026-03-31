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

        public IActionResult Upsert(int? id, string returnUrl)
        {
            Note? noteToEdit = null;
            if (id != null)
            {
                noteToEdit = _context.Notes.FirstOrDefault(note => note.Id == id);
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(noteToEdit);
        }

        [HttpPost]
        public IActionResult Upsert(Note note)
        {
            if (ModelState.IsValid)
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
            ViewBag.ReturnUrl = "/";
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Note? noteToDelete = _context.Notes.FirstOrDefault(note => note.Id == id);
            if (noteToDelete != null)
                return View(noteToDelete);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(Note noteToDelete)
        {
            if (noteToDelete == null)
                return NotFound();
            _context.Notes.Remove(noteToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
