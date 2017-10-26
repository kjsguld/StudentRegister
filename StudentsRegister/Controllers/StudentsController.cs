using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsRegister.Models;

namespace StudentsRegister.Controllers
{
    public class StudentsController : Controller
    {
        private StudentsContext db = new StudentsContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
    }
}