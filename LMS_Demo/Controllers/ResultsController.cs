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

    public class ResultsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ResultsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Results
       // [Authorize(Roles = "Facilitator")]
        public IActionResult Index(int? id)
        {
            var results = _context.Results.Where(r => r.AssessmentID==id).Include(r => r.Assesment).Include(r => r.Student).Include(r => r.Facilitator);
            return View(results.ToList());
        }

        //Give result only for teachers
        [HttpPost]
       // [Authorize(Roles = "Facilitator")]
        public IActionResult Index(List<Result> resultList)
        {
            //     List<Result> resultList = new List<Result>();
            //   resultList = IEResult.ToList();
            if (ViewData["RoleName"] != null)
            {
                if (ViewData["RoleName"].ToString() == "Facilitator")
                 {
                    if (ModelState.IsValid)
                    { 
                    foreach(Result s in resultList)
                    {
                        Result singleResult = _context.Results.Where(m => m.StudentID == s.StudentID && m.AssessmentID == s.AssessmentID).SingleOrDefault();
                        if (singleResult != null)
                        {
                            singleResult.Mark = s.Mark;
                        }
                    }
                        _context.SaveChanges();
                    ViewBag.Message = "1";
                        var results = _context.Results.Include(r => r.Assesment).Include(r => r.Student).Include(r => r.Facilitator);
                        return View( );
                    } 
                }
            } 
            ViewBag.Message = "0";
            var resultsg = _context.Results.Include(r => r.Assesment).Include(r => r.Student).Include(r => r.Facilitator);
            return View(resultsg.ToList()); 
            
        }

        //View Result Only for students
        //[Authorize(Roles = "Students")]
        public IActionResult ViewResult()
        {
            int SID = Convert.ToInt32(ViewData["ID"]); 
            var results = _context.Results.Where(r => r.StudentID==SID).Include(r => r.Assesment).Include(r => r.Student).Include(r => r.Facilitator);
            return View(results.ToList());
        }

        // GET: Results/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Results.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Results/Create
       // [Authorize(Roles = "Facilitator,Admin")]
        public IActionResult Create()
        {
 
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Facilitator,Admin")]
        public IActionResult Create(Result obj)
        {
            if (ModelState.IsValid)
            {
                _context.Results.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssessmentID = new SelectList(_context.Assesments, "SysId", "Id", obj.AssessmentID);
            ViewBag.StudentID = new SelectList(_context.Students, "SysId", "Id", obj.StudentID);
         
            return View(obj);
        }

        // GET: Results/Edit/5
       // [Authorize(Roles = "Facilitator,Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Results.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
            ViewBag.AssessmentID = new SelectList(_context.Assesments, "SysId", "Id", obj.AssessmentID);
            ViewBag.StudentID = new SelectList(_context.Students, "SysId", "Id", obj.StudentID);
            ViewBag.CreatedBy = new SelectList(_context.Facilitators, "SysId", "Id", obj.CreatedBy);
            return View(obj);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Facilitator,Admin")]
        public IActionResult Edit(Result obj)
        {
            if (ModelState.IsValid)
            {
                _context.Results.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssessmentID = new SelectList(_context.Assesments, "SysId", "Id", obj.AssessmentID);
            ViewBag.StudentID = new SelectList(_context.Students, "SysId", "Id", obj.StudentID);
            ViewBag.CreatedBy = new SelectList(_context.Facilitators, "SysId", "Id", obj.CreatedBy);
            return View(obj);
        }

        // GET: Results/Delete/5
        //[Authorize(Roles = "Facilitator,Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Results.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Facilitator,Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            Result result = _context.Results.Find(id);
            _context.Results.Remove(result);
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
