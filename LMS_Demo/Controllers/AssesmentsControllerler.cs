using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS_Demo.Data;
using LMS_Demo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace LMS_Demo.Controllers
{
    public class AssesmentsControllerler : Controller
    {
        private readonly ApplicationDBContext _context;

        public AssesmentsControllerler(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int id = Convert.ToInt32(ViewData["ID"]);
            var department = _context.Teaches.Where(d => d.TeacherId == id).Select(td => td.DepartmentId).ToList();
            var year = _context.Teaches.Where(d => d.TeacherId == id).Select(td => td.YearId);
            var section = _context.Teaches.Where(d => d.TeacherId == id).Select(td => td.SectionId);
            //       var assesments = db.Assesments.Include(a => a.AssesmentType).Include(a => a.Course).Include(a => a.Department).Include(a => a.Section).Include(a => a.Year);
            IEnumerable<Assesment> assesments = null;
            foreach (var dept in department)
            {
                assesments = _context.Assesments.Where(s => s.DepartmentID == dept.Value);

                foreach (var y in year)
                {
                    assesments = assesments.Where(s => s.YearID == y.Value);
                    foreach (var s in section)
                    {
                        assesments = assesments.Where(x => x.YearID == s.Value);
                    }
                }
            }
            if (assesments != null)
            {
                return View(assesments.ToList());
            }
            else
            {
                return View();
            }

        }
        // GET: Assesments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Assesment assesment = _context.Assesments.Find(id);
            if (assesment == null)
            {
                return NotFound();
            }
            return View(assesment);
        }

        // GET: Assesments/Create


        //// POST: Assesments/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Assesment assesment)
        {
            if (ModelState.IsValid)
            {
                //check whether selected department and yead takes that specific course
                int studCourse = _context.Courses.Where(c => c.SysId == assesment.CourseID && c.YearId == assesment.YearID).Count();
                if (studCourse > 0)
                {
                    assesment.CreatedBy = Convert.ToInt32(ViewData["ID"]);
                    _context.Assesments.Add(assesment);
                    _context.SaveChanges();
                    List<Result> resultList = new List<Result>();
                    Result result = new Result();
                    List<Student> studentList = _context.Students.Where(x => x.SectionID == assesment.SectionID && x.YearID == assesment.YearID && x.DepartmentID == assesment.DepartmentID).ToList();
                    foreach (Student student in studentList)
                    {
                        result.StudentID = student.SysId;
                        result.AssessmentID = assesment.SysId;
                        result.CreatedBy = Convert.ToInt32(ViewData["TeacherSysID"]);
                        _context.Results.Add(result);
                        _context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.StudentCourse = "The Selected department or Year does not match with the selected course";
                }
            }

            ViewBag.Type = new SelectList(_context.AssesmentTypes, "SysId", "Name", assesment.Type);
            ViewBag.CourseID = new SelectList(_context.Courses, "SysId", "Name", assesment.CourseID);
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name", assesment.DepartmentID);
            ViewBag.SectionID = new SelectList(_context.Sections, "SysId", "Value", assesment.SectionID);
            ViewBag.YearID = new SelectList(_context.Years, "SysId", "Value", assesment.YearID);
            return View();
        }

        //upload assesment
        [HttpPost]
        public IActionResult UploadAttachment(AssesmentAttachmentsModel membervalues)
        {
            if (membervalues.File != null)
            {
                string FileName = Path.GetFileNameWithoutExtension(membervalues.File.FileName);
                string FileExtension = Path.GetExtension(membervalues.File.FileName);
                FileName = FileName.Trim() + FileExtension;
                //maps server path automatically
                var path = Path.Combine(("~/Content/SubmittedFiles/"), FileName);
                //Its Create complete path to store in server.   
                membervalues.Attachment = path;
                //To copy and save file into server.  
                membervalues.File.SaveAs(membervalues.Attachment);
            }
            Assesment assesment = new Assesment();
            assesment.AssesmentType = membervalues.AssesmentType;
            assesment.Attachment = membervalues.Attachment;
            assesment.Course = membervalues.Course;
            assesment.CourseID = membervalues.CourseID;
            assesment.CreatedBy = Convert.ToInt32(ViewData["ID"]);
            assesment.DeadLine = membervalues.DeadLine;
            assesment.Department = membervalues.Department;
            assesment.DepartmentID = membervalues.DepartmentID;
            assesment.Description = membervalues.Description;
            assesment.GivenDate = membervalues.GivenDate;
            assesment.Id = membervalues.Id;
            assesment.IsDeleted = membervalues.IsDeleted;
            assesment.Section = membervalues.Section;
            assesment.SectionID = membervalues.SectionID;
            assesment.Facilitator = membervalues.Facilitator;
            assesment.Time = membervalues.Time;
            assesment.Title = membervalues.Title;
            assesment.TotalMark = membervalues.TotalMark;
            assesment.Type = membervalues.Type;
            assesment.Year = membervalues.Year;
            assesment.YearID = membervalues.YearID;
            //  db.Assesments.Add(assesment);
            //  db.SaveChanges();
            if (ViewData["operation"].ToString() == "create")
            {
                return Create(assesment);
                // return RedirectToAction("Create", assesment);

            }
            else if (ViewData["operation"].ToString() == "edit")
            {
                return Edit(assesment);
            }

            return RedirectToAction("Index");
        }

        // GET: Assesments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Assesment assesment = _context.Assesments.Find(id);
            ViewData["AssesmentCreatedDate"] = assesment.GivenDate;
            ViewData["AssesmentDeadline"] = assesment.DeadLine;
            ViewData["AssesmentAttachement"] = assesment.Attachment;
            ViewData["AssesmentSysId"] = assesment.SysId;
            if (assesment == null)
            {
                return NotFound();
            }
            ViewBag.Type = new SelectList(_context.AssesmentTypes, "SysId", "Name", assesment.Type);
            ViewBag.CourseID = new SelectList(_context.Courses, "SysId", "Name", assesment.CourseID);
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name", assesment.DepartmentID);
            ViewBag.SectionID = new SelectList(_context.Sections, "SysId", "Value", assesment.SectionID);
            ViewBag.YearID = new SelectList(_context.Years, "SysId", "Value", assesment.YearID);
            return View(assesment);
        }

        // POST: Assesments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(include:  "SysId,Id,Type,Time,GivenDate,DeadLine,SectionID,DepartmentID,CourseID,YearID,Title,Description,TotalMark,CreatedBy,IsDeleted,Attachment")] Assesment assesment)
        {
            if (ModelState.IsValid)
            {
                assesment.CreatedBy = Convert.ToInt32(ViewData["ID"]);
                assesment.GivenDate = DateTime.Parse(ViewData["AssesmentCreatedDate"].ToString());
                assesment.SysId = Convert.ToInt32(ViewData["AssesmentSysId"].ToString());
                assesment.Id = ViewData["AssesmentSysId"].ToString();
                if (assesment.Attachment == null)
                {
                    if (ViewData["AssesmentAttachement"] != null)
                    {
                        assesment.Attachment = ViewData["AssesmentAttachement"].ToString();
                    }

                }
                if (assesment.DeadLine == null)
                {
                    assesment.DeadLine = DateTime.Parse(ViewData["AssesmentDeadline"].ToString());
                }
                _context.Entry(assesment).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(_context.AssesmentTypes, "SysId", "Name", assesment.Type);
            ViewBag.CourseID = new SelectList(_context.Courses, "SysId", "Name", assesment.CourseID);
            ViewBag.DepartmentID = new SelectList(_context.Departments, "SysId", "Name", assesment.DepartmentID);
            ViewBag.SectionID = new SelectList(_context.Sections, "SysId", "Value", assesment.SectionID);
            ViewBag.YearID = new SelectList(_context.Years, "SysId", "Value", assesment.YearID);
            return View(assesment);
        }

        // GET: Assesments/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError); ;
            }
            Assesment assesment = _context.Assesments.Find(id);
            if (assesment == null)
            {
                return NotFound();
            }
            return View(assesment);
        }

        // POST: Assesments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            List<SubmitAssignment> submitAssignments = _context.SubmitAssignments.Where(sa => sa.AssesmentId == id).ToList();
            List<Result> results = _context.Results.Where(r => r.AssessmentID == id).ToList();
            foreach (SubmitAssignment sa in submitAssignments)
            {
                _context.SubmitAssignments.Remove(sa);
                _context.SaveChanges();
            }
            foreach (Result r in results)
            {
                _context.Results.Remove(r);
                _context.SaveChanges();
            }
            Assesment assesment = _context.Assesments.Find(id);
            _context.Assesments.Remove(assesment);
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
