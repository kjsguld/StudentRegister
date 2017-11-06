using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsRegister.Models;
using System.Net;

namespace StudentsRegister.Controllers
{
    public class StudentsController : Controller
    {
        private StudentsContext db = new StudentsContext();

        /// <summary>
        /// Gets a list of students
        /// </summary>
        /// <returns>list of students</returns>
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        /// <summary>
        /// Returns a student queried by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A student object</returns>
        public ActionResult Details(int? id)
        {
            //if no ID is provided 
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //find student by id
            var student = db.Students.Find(id);
            //if the student doesn't exist
            if (student == null)
            {
                return HttpNotFound();
            }
            //if the student exists
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}