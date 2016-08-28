using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A01.Models;
using Microsoft.AspNetCore.Mvc;

namespace A01.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private static List<Student> _students;

        public StudentsController()
        {
            if (_students == null)
            {
                _students = new List<Student>
                {
                    new Student()
                    {
                        SSN = 123456,
                        Name = "David Webber"
                    },
                    new Student()
                    {
                        SSN = 234567,
                        Name = "Orson Scott Card"
                    },
                    new Student()
                    {
                        SSN = 345678,
                        Name = "Terry Goodkind"
                    },
                    new Student()
                    {
                        SSN = 456789,
                        Name = "Margaret Weis"
                    }
                };
            }
        }

        // GET api/students
        [HttpGet]
        public List<Student> GetStudents()
        {
            return _students;
        }
    }
}
