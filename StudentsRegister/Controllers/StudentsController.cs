using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsRegister.Models;
using System.Net;
using System.IO;

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
            Student student = db.Students.Find(id);
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student, HttpPostedFileBase imageFile)
        {
            using (var ms = new MemoryStream())
            {
                imageFile.InputStream.CopyTo(ms);
                student.Picture = ms.ToArray();
            }

                db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            db.Entry(student).State = System.Data.Entity.EntityState.Added;
            //db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}