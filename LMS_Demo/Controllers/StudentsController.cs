using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LMS_Demo.Data;
using LMS_Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS_Demo.Controllers
{
    //[Authorize(Roles = "Facilitator,Admin")]
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public StudentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Students
        public IActionResult Index()
        {
            int ID = Convert.ToInt32(ViewData["ID"]);
            int unRead = _context.Messages.Count(x => (x.ToFacilitator == ID) && x.Status == 1);
            ViewData["unRead"] = unRead;
            int id = Convert.ToInt32(ViewData["ID"]);
            var department = _context.Teaches.Where(d => d.TeacherId == id).Select(td => td.DepartmentId).ToList();
            var year = _context.Teaches.Where(d => d.TeacherId == id).Select(td => td.YearId);
            var section = _context.Teaches.Where(d => d.TeacherId == id).Select(td => td.SectionId);
            IEnumerable<Student> student=null;
            //var students = db.Students.Include(s => s.Department).Include(s => s.Role1).Include(s => s.Section).Include(s => s.Teacher).Include(s => s.Year);
          
            {
                 student = _context.Students;
                return View(student.ToList());
            }

            foreach(var dept in department)
            {
                student= _context.Students.Where(s => s.DepartmentID == dept.Value);

                foreach (var y in year)
                {
                    student = student.Where(s => s.YearID == y.Value);
                    foreach(var s in section)
                    {
                        student = student.Where(x => x.YearID == s.Value);
                    }
                }
            }
            // student = student.Include(s => s.Department).Include(s => s.Role1).Include(s => s.Section).Include(s => s.Teacher).Include(s => s.Year);
            if (student != null)
            {
                return View(student.ToList());
            }
            else
            {
                return View();
            }
            
        }

        // GET: Students/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            int id = Convert.ToInt32(ViewData["ID"]); 
           
            {
                ViewBag.DepartmentID = new SelectList(_context.Teaches.Where(d => d.TeacherId == id).Select(td => td.Department), "SysId", "Name");
                ViewBag.SectionID = new SelectList(_context.Teaches.Where(d => d.TeacherId == id).Select(td => td.Section), "SysId", "Value");
                ViewBag.YearID = new SelectList(_context.Teaches.Where(d => d.TeacherId == id).Select(td => td.Year), "SysId", "Value");
            }
            
            {
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name");
            ViewBag.SectionID = new SelectList(_context.Sections, "SysId", "Value");
            ViewBag.YearID = new SelectList(_context.Years, "SysId", "Value");
            }
            

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name", obj.DepartmentID);
            ViewBag.Role = new SelectList(_context.Roles, "SysId", "Name", obj.Role);
            ViewBag.SectionID = new SelectList(_context.Sections, "SysId", "Value", obj.SectionID);
            ViewBag.CreatedBy = new SelectList(_context.Facilitators, "SysId", "Id", obj.CreatedBy);
            ViewBag.YearID = new SelectList(_context.Years, "SysId", "Value", obj.YearID);
            return View(obj);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name", obj.DepartmentID);
            ViewBag.Role = new SelectList(_context.Roles, "SysId", "Name", obj.Role);
            ViewBag.SectionID = new SelectList(_context.Sections, "SysId", "Value", obj.SectionID);
            ViewBag.CreatedBy = new SelectList(_context.Facilitators, "SysId", "Id", obj.CreatedBy);
            ViewBag.YearID = new SelectList(_context.Years, "SysId", "Value", obj.YearID);
            return View(obj);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name", obj.DepartmentID);
            ViewBag.Role = new SelectList(_context.Roles, "SysId", "Name", obj.Role);
            ViewBag.SectionID = new SelectList(_context.Sections, "SysId", "Value", obj.SectionID);
            ViewBag.CreatedBy = new SelectList(_context.Facilitators, "SysId", "Id", obj.CreatedBy);
            ViewBag.YearID = new SelectList(_context.Years, "SysId", "Value", obj.YearID);
            return View(obj);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
            Student student = _context.Students.Find(id);
                _context.Students.Remove(student);
                _context.SaveChanges();
            return RedirectToAction("Index");
            }catch(Exception e)
            {
                ModelState.AddModelError("","This student has ongoing sessions. Please end these sessions before delete");
                return View();
            }

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
