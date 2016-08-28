using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A01.Models;
using Microsoft.AspNetCore.Mvc;

namespace A01.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private static List<Course> _courses;

        public CoursesController()
        {
            if (_courses == null)
            {
                _courses = new List<Course>
                {
                    new Course()
                    {
                        ID = 1,
                        Name = "Web Services",
                        TemplateID = "T-514-VEFT",
                        StartDate = Convert.ToDateTime("17/08/2016"),
                        EndDate = Convert.ToDateTime("08/11/2016"),
                        ListOfStudents = new List<Student>
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
                            }
                        }
                    },
                    new Course()
                    {
                        ID = 2,
                        Name = "Computer Networking",
                        TemplateID = "T-409-TSAM",
                        StartDate = Convert.ToDateTime("17/08/2016"),
                        EndDate = Convert.ToDateTime("08/11/2016"),
                        ListOfStudents = new List<Student>
                        {
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
                        }
                    }
                };
            }
        }

        // GET api/courses
        [HttpGet]
        public List<Course> GetCourses()
        {
            return _courses;
        }

        // GET api/courses/5
        [HttpGet]
        [Route("{id}", Name = "GetCourseByID")]
        public IActionResult GetCourseByID(int id)
        {
            foreach (var c in _courses)
            {
                if (c.ID == id)
                {
                    return new ObjectResult(c);
                }
            }
            return NotFound();
        }

        // POST api/courses
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/courses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/courses/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
