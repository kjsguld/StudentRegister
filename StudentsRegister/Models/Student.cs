using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public string GetBirthdate
        {
            get
            {
                return Birthdate.ToString("dd/MM/yyyy");
            }
        }

        public GenderType Gender { get; set; }

        public enum GenderType
        {
            Male,
            Female
        }
    }
}