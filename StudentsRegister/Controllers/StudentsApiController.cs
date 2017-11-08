using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentsRegister.Models;

namespace StudentsRegister.Controllers
{
    public class StudentsApiController : ApiController
    {
        private StudentsContext db = new StudentsContext();

        // GET api/studentsApi
        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }

        // GET api/StudentsApi/2
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            // try to find a student in the students table
            Student student = db.Students.Find(id);
            
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);

        }

    }
}
