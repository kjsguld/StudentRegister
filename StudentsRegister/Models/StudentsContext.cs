using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentsRegister.Models
{
    public class StudentsContext : DbContext
    {
        public StudentsContext() : base("Students")
        {
            Database.SetInitializer<StudentsContext>(new DBInitializer());
        }
        public DbSet<Student> Students { get; set; }
    }

    public class DBInitializer : DropCreateDatabaseIfModelChanges<StudentsContext>
    {
        protected override void Seed(StudentsContext context)
        {
            var students = new List<Student>
            {
                new Student { Name = "John Doe", CPR = "1233", Gender = 'M', Birthdate = new DateTime(2000,10,25)},
                new Student { Name = "Jonna Doe", CPR = "5234", Gender = 'F', Birthdate = new DateTime(2000,5,25)},
                new Student { Name = "Simon Doe", CPR = "7837", Gender = 'M', Birthdate = new DateTime(1993,10,16)},
                new Student { Name = "Niclas Doe", CPR = "2365", Gender = 'M', Birthdate = new DateTime(1994,4,25)},
                new Student { Name = "Kristian Doe", CPR = "1259", Gender = 'M', Birthdate = new DateTime(1993,7,19)},
                new Student { Name = "Anders Doe", CPR = "4573", Gender = 'M', Birthdate = new DateTime(1994,4,25)}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
        }
    }
}