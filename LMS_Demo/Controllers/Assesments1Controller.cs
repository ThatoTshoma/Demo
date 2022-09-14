using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS_Demo.Data;
using LMS_Demo.Models;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace LMS_Demo.Controllers
{
    public class Assesments1Controller : Controller
    {
        private readonly ApplicationDBContext _context;

        public Assesments1Controller(ApplicationDBContext context)
        {
            _context = context;
        }
        public IQueryable<Assesment> GetAssesments()
        {
            return _context.Assesments;
        }

        // GET: api/Assesments1/5
        [ResponseType(typeof(Assesment))]
        public IHttpActionResult GetAssesment(int id)
        {
            Assesment assesment = _context.Assesments.Find(id);
            if (assesment == null)
            {
                return (IHttpActionResult)NotFound();
            }

            return (IHttpActionResult)Ok(assesment);
        }

        // PUT: api/Assesments1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssesment(int id, Assesment assesment)
        {
            if (!ModelState.IsValid)
            {
                return (IHttpActionResult)BadRequest(ModelState);
            }

            if (id != assesment.SysId)
            {
                return (IHttpActionResult)BadRequest();
            }

            _context.Entry(assesment).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssesmentExists(id))
                {
                    return (IHttpActionResult)NotFound();
                }
                else
                {
                    throw;
                }
            }

            return (IHttpActionResult)Ok(assesment);
        }

        // POST: api/Assesments1
        [ResponseType(typeof(Assesment))]
        public IHttpActionResult PostAssesment(Assesment assesment)
        {
            if (!ModelState.IsValid)
            {
                return (IHttpActionResult)BadRequest(ModelState);
            }

            _context.Assesments.Add(assesment);
            _context.SaveChanges();

            return (IHttpActionResult)CreatedAtRoute("DefaultApi", new { id = assesment.SysId }, assesment);
        }

        // DELETE: api/Assesments1/5
        [ResponseType(typeof(Assesment))]
        public IHttpActionResult DeleteAssesment(int id)
        {
            Assesment assesment = _context.Assesments.Find(id);
            if (assesment == null)
            {
                return (IHttpActionResult)NotFound();
            }

            _context.Assesments.Remove(assesment);
            _context.SaveChanges();

            return (IHttpActionResult)Ok(assesment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssesmentExists(int id)
        {
            return _context.Assesments.Count(e => e.SysId == id) > 0;
        }
    }
}
