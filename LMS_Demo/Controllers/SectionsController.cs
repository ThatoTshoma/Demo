using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS_Demo.Data;
using LMS_Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS_Demo.Controllers
{
   // [Authorize(Roles = "Teachers,Admin")]
    public class SectionsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SectionsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Sections
        public IActionResult Index()
        {
            var sections = _context.Sections.Include(s => s.Year);
            return View(sections.ToList());
        }

        // GET: Sections/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Sections.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            ViewBag.YearId = new SelectList(_context.Years, "SysId", "Value");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Section obj)
        {
            if (ModelState.IsValid)
            {
                _context.Sections.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YearId = new SelectList(_context.Years, "SysId", "Value", obj.YearId);
            return View(obj);
        }

        // GET: Sections/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Sections.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Section obj)
        {
            if (ModelState.IsValid)
            {
                _context.Sections.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YearId = new SelectList(_context.Years, "SysId", "Value", obj.YearId);
            return View(obj);
        }

        // GET: Sections/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Sections.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Section section = _context.Sections.Find(id);
            _context.Sections.Remove(section);
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
