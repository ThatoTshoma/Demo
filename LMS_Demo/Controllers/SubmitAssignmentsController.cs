using Microsoft.EntityFrameworkCore;
using LMS_Demo.Data;
using LMS_Demo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS_Demo.Controllers
{

    public class SubmitAssignmentsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SubmitAssignmentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: SubmitAssignments// is for teachers
        //[Authorize(Roles = "Facilitator")]
        public IActionResult Index(int? assesmentID)
        {            
            var submitAssignments = _context.SubmitAssignments.Where(x => x.AssesmentId== assesmentID).Include(s => s.Assesment).Include(s => s.Student);
            return View(submitAssignments.ToList());
        }

        //
        // GET: jjjSubmitAssignments1/Create
        public IActionResult Create(int? assesmentID)
        {
            ViewBag.AssesmentId = assesmentID;// new SelectList(db.Assesments, "SysId", "Id");
            ViewBag.StudentId = new SelectList(_context.Students, "SysId", "Id");
            return View();
        }

        // POST: jjjSubmitAssignments1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubmitAssignment obj)
        {
            if (ModelState.IsValid)
            {
                _context.SubmitAssignments.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

            ViewBag.AssesmentId = new SelectList(_context.Assesments, "SysId", "Id", obj.AssesmentId);
            ViewBag.StudentId = new SelectList(_context.Students, "SysId", "Id", obj.StudentId);
            return View(obj);
        }

        // GET: SubmitAssignments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.SubmitAssignments.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: SubmitAssignments/Edit/5
        //[Authorize(Roles = "Teachers,Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.SubmitAssignments.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
            ViewBag.AssesmentId = new SelectList(_context.Assesments, "SysId", "Id", obj.AssesmentId);
            ViewBag.StudentId = new SelectList(_context.Students, "SysId", "Id", obj.StudentId);
            return View(obj);
        }

        // POST: SubmitAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Teachers,Admin")]
        public IActionResult Edit(SubmitAssignment obj)
        {
            if (ModelState.IsValid)
            {
                _context.SubmitAssignments.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssesmentId = new SelectList(_context.Assesments, "SysId", "Id", obj.AssesmentId);
            ViewBag.StudentId = new SelectList(_context.Students, "SysId", "Id", obj.StudentId);
            return View(obj);
        }

        // GET: SubmitAssignments/Delete/5
       // [Authorize(Roles = "Facilitator,Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.SubmitAssignments.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: SubmitAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Teachers,Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            SubmitAssignment submitAssignment = _context.SubmitAssignments.Find(id);
            _context.SubmitAssignments.Remove(submitAssignment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Upload Assignmnets for Students
        [HttpPost]
        //[Authorize(Roles = "Students")]
        public IActionResult Upload(SubmitAssignmentModel membervalues)
        {
            string FileName = Path.GetFileNameWithoutExtension(membervalues.File.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(membervalues.File.FileName);

            FileName = membervalues.StudentId + "-" + membervalues.AssesmentId+"-"+ FileName.Trim() + FileExtension;
             //maps server path automatically
            var path = Path.Combine(("~/Content/SubmittedFiles/"), FileName);
            //Its Create complete path to store in server.   
            membervalues.FilePath = path;
            //To copy and save file into server.  
            membervalues.File.SaveAs(membervalues.FilePath);

            SubmitAssignment submitAssignment = new SubmitAssignment();
            submitAssignment.StudentId = membervalues.StudentId;
            submitAssignment.AssesmentId = membervalues.AssesmentId;
            submitAssignment.FilePath = membervalues.FilePath;
            String now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//make it datetime
            submitAssignment.SubmissionDate = DateTime.Parse(now);

            _context.SubmitAssignments.Add(submitAssignment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Download Assignments For teachers
        //[Authorize(Roles = "Teachers,Admin")]
        public void Download(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string path = Path.Combine(("~/Content/SubmittedFiles/"), fileName);//map file on server
            FileInfo file = new FileInfo(path);
           /* if (file.Exists)
            { 
                Response.Clear();
                
                Response.AppendHeader("content-disposition", "attachement; filename= " + fileName); 
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(path); 
            }*/
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
