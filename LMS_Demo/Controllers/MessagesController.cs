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
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MessagesController(ApplicationDBContext context)
        {
            _context = context;
        }


        // GET: Messages
        public IActionResult Index(string show)
        {
            if (show == null)
            {
                show = "inbox";
            }
            string name = ViewData["Name"].ToString();
            int ID = Convert.ToInt32(ViewData["ID"]); 
            if (ViewData["RoleName"].ToString() == "Facilitator")
            {
                //count unread messages
                int unRead = _context.Messages.Count(x => (x.ToFacilitator == ID) && x.Status == 1);
                ViewData["unRead"] = unRead;
                if(show=="outbox")
                {
                    var outBox = _context.Messages.Where(m => m.From == name).Include(m => m.Student).Include(m => m.Student).Include(m => m.Facilitator).Include(m => m.Facilitator); ;
                    return View(outBox.ToList());
                }
                else if (show == "inbox")
                {
                    var inBox = _context.Messages.Where(m => m.ToFacilitator == ID).Include(m => m.Student).Include(m => m.Student).Include(m => m.Facilitator).Include(m => m.Facilitator); ;
                    return View(inBox.ToList());
                }
                else if (show == "all")
                {
                    var all = _context.Messages.Where(m => m.ToFacilitator == ID||m.From == name).Include(m => m.Student).Include(m => m.Student).Include(m => m.Facilitator).Include(m => m.Facilitator); ;
                    return View(all.ToList());
                }
                
            }
            if (ViewData["RoleName"].ToString() == "Students")
            {
            //count unread messages
            int unRead = _context.Messages.Count(x => (x.ToStudents == ID) && x.Status == 1);
                ViewData["unRead"] = unRead;
            if(show=="outbox")
                {
                    var outBox = _context.Messages.Where(m => m.From == name).Include(m => m.Student).Include(m => m.Student).Include(m => m.Facilitator).Include(m => m.Facilitator); ;
                    return View(outBox.ToList());
                }
            else if (show == "inbox")
                {
                var inBox = _context.Messages.Where(m => m.ToStudents == ID).Include(m => m.Student).Include(m => m.Facilitator);
                return View(inBox.ToList());
                }
            else if (show == "all")
                {
                    var inBox = _context.Messages.Where(m => m.ToStudents == ID||m.From == name).Include(m => m.Student).Include(m => m.Student).Include(m => m.Facilitator).Include(m => m.Facilitator); ;
                    return View(inBox.ToList());
                }

            }
            var msg = _context.Messages.Where(m => m.Status==99);//means no message
            return View(msg);
        }

        // GET: Messages/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Message message = _context.Messages.Find(id);
            message.Status = 0;
            _context.Entry(message).State = EntityState.Modified;
            _context.SaveChanges();
            int ID = Convert.ToInt32(ViewData["ID"]);
            if (ViewData["RoleName"].ToString() == "Facilitator")
            {
                //count unread messages
                int unRead = _context.Messages.Count(x => (x.ToFacilitator == ID) && x.Status == 1);
                ViewData["unRead"] = unRead;
            }
            else if (ViewData["RoleName"].ToString() == "Students")
            {
                int unRead = _context.Messages.Count(x => (x.ToStudents == ID) && x.Status == 1);
                ViewData["unRead"] = unRead;
            }
                if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            if (ViewData["RoleName"].ToString() == "Facilitator")
            {
                int id = Convert.ToInt32(ViewData["ID"]);
                var department = _context.Teaches.Where(d => d.TeacherId == id).Select(td => td.DepartmentId).ToList();
                var year = _context.Teaches.Where(d => d.TeacherId == id).Select(td => td.YearId);
                var section = _context.Teaches.Where(d => d.TeacherId == id).Select(td => td.SectionId);
                IEnumerable<Student> student = null;
                foreach (var dept in department)
                {
                    student = _context.Students.Where(s => s.DepartmentID == dept.Value);

                    foreach (var y in year)
                    {
                        student = student.Where(s => s.YearID == y.Value);
                        foreach (var s in section)
                        {
                            student = student.Where(x => x.YearID == s.Value);
                        }
                    }
                }
                if (student != null)
                {
                ViewBag.ToStudents = new SelectList(student, "SysId", "FullName");
                }
                else
                {
                ViewBag.ToStudents = new SelectList(_context.Students.Where(x => x.FullName=="No Students"),"SysId","FullNama");
                }

                ViewBag.CreatedBy = new SelectList(_context.Facilitators, "SysId", "Id");
            }
            else if (ViewData["RoleName"].ToString() == "Students")
            {
                int deptID = Convert.ToInt32(ViewData["Department"]);
                int SecID = Convert.ToInt32(ViewData["Section"]);
                int YrID = Convert.ToInt32(ViewData["Year"]);

                ViewBag.CreatedBy = new SelectList(_context.Students, "SysId", "Id");
                ViewBag.ToTeachers = new SelectList(_context.Teaches.Where(c => c.DepartmentId == deptID && c.YearId == YrID && c.SectionId == SecID).Select(x => x.Facilitator), "SysId", "FullName");
            
                return View();
            }
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Message obj)
        {
            if (ModelState.IsValid)
            {
                obj.Status = 1;
                obj.IsDeleted = 0;
                obj.SentDate = DateTime.Now;
                _context.Messages.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            if(ViewData["RoleName"].ToString() == "Facilitator")
            {
            ViewBag.ToStudents = new SelectList(_context.Students, "SysId", "Id", obj.ToStudents); 
            }
            else if(ViewData["RoleName"].ToString() == "Students")
            {
            ViewBag.ToTeachers = new SelectList(_context.Facilitators, "SysId", "Id", obj.ToFacilitator); 
            }

            return View(obj);
        }

        // GET: Messages/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Messages.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Message message = _context.Messages.Find(id);
            _context.Messages.Remove(message);
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
