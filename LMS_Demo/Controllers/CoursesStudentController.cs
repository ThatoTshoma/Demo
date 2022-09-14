using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS_Demo.Data;
using LMS_Demo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace LMS_Demo.Controllers
{
    public class CoursesStudentController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CoursesStudentController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            int ID = Convert.ToInt32(ViewData["ID"]);
            int unRead = _context.Messages.Count(x => (x.ToStudents == ID) && x.Status == 1);
            ViewData["unRead"] = unRead;
            int deptID = Convert.ToInt32(ViewData["Department"]);
            int SecID = Convert.ToInt32(ViewData["Section"]);
            int YrID = Convert.ToInt32(ViewData["Year"]);
            IEnumerable<Course> courses = _context.Teaches.Where(c => c.DepartmentId == deptID && c.YearId == YrID && c.SectionId == SecID).Select(x => x.Course);
            return View(courses.ToList());
            
        }
        public IActionResult AssesmentsUnderCourse(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            int dept = Convert.ToInt32(ViewData["Department"]);
            int year = Convert.ToInt32(ViewData["Year"]);
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime today = DateTime.Parse(date);
            var assesments = _context.Assesments.Where(a => a.CourseID == id && a.YearID == year && a.DepartmentID == dept && a.DeadLine >= today);
            if (assesments == null)
            {
                return NotFound();
            }
            return View(assesments);
        }

        public IActionResult AllAssignments(string name)
        {
            ViewBag.Head = name + "s";
            int dept = Convert.ToInt32(ViewData["Department"]);
            int year = Convert.ToInt32(ViewData["Year"]);
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime today = DateTime.Parse(date);
            var assesments = _context.Assesments.Where(a => a.AssesmentType.Name == name && a.YearID == year && a.DepartmentID == dept && a.DeadLine >= today);
            if (assesments == null)
            {
                return NotFound();
            }
            return View(assesments);
        }
        public IActionResult AllTests()
        {
            int dept = Convert.ToInt32(ViewData["Department"]);
            int year = Convert.ToInt32(ViewData["Year"]);
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime today = DateTime.Parse(date);
            var assesments = _context.Assesments.Where(a => a.AssesmentType.Name == "Test" && a.YearID == year && a.DepartmentID == dept && a.DeadLine >= today);
            if (assesments == null)
            {
                return NotFound();
            }
            return View(assesments);
        }

        //Download Assesment Attachments For students
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

