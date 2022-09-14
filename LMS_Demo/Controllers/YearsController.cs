using Microsoft.EntityFrameworkCore;
using LMS_Demo.Data;
using LMS_Demo.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace LMS_Demo.Controllers
{
    public class YearsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public YearsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Years
        public IActionResult Index()
        {
            return View(_context.Years.ToList());
        }

        // GET: Years/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Years.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Years/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Years/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Year obj)
        {
            if (ModelState.IsValid)
            {
                _context.Years.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: Years/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Years.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Years/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Year obj)
        {
            {
               _context.Years.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: Years/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Years.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Years/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Year obj)
        {
            _context.Years.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
