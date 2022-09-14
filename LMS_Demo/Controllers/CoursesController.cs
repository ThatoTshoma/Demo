using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.EntityFrameworkCore;
using LMS_Demo.Data;
using LMS_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS_Demo.Controllers
{
   // [Authorize(Roles = "Teachers,Admin")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CoursesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Courses
        public IActionResult Index()
        {
            int TID = Convert.ToInt32(ViewData["ID"]);
            var courses = _context.Courses.Include(c => c.Department).Include(c => c.Year);
            return View(courses.ToList());
            
           
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Course course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name");
            ViewBag.YearId = new SelectList(_context.Years, "SysId", "Value");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course obj)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name", obj.DepartmentID);
            ViewBag.YearId = new SelectList(_context.Years, "SysId", "Value", obj.YearId);
            return View(obj);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Value", obj.DepartmentID);
            ViewBag.YearId = new SelectList(_context.Years, "SysId", "Value", obj.YearId);
            return View(obj);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedBy = Convert.ToInt32(ViewData["ID"]);
                _context.Courses.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name", obj.DepartmentID);
            ViewBag.YearId = new SelectList(_context.Years, "SysId", "Value", obj.YearId);
            return View(obj);
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Course course = _context.Courses.Find(id);
            _context.Courses.Remove(course);
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
