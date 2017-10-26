using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsRegister.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string CPR { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public char Gender { get; set; }

    }
}