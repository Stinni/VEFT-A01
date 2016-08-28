using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using A01.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
            return new NotFoundResult();
        }

        // POST api/courses
        [HttpPost]
        public IActionResult AddCourse([FromBody]Course course)
        {
            if (course == null)
            {
                return new BadRequestResult();
            }
            foreach (var c in _courses)
            {
                if (c.ID == course.ID)
                {
                    return new StatusCodeResult(409);
                }
            }
            _courses.Add(course);
            var location = Url.Link("GetCourseByID", new {id = course.ID});
            return new CreatedResult(location, course);
        }

        // PUT api/courses/5
        [HttpPut]
        [Route("{id}", Name = "UpdateCourse")]
        public IActionResult UpdateCourse(int id, [FromBody]Course course)
        {
            if (course == null)
            {
                return new BadRequestResult();
            }
            foreach (var c in _courses)
            {
                if (c.ID != id) continue;
                c.Name = course.Name;
                c.TemplateID = course.TemplateID;
                c.StartDate = course.StartDate;
                c.EndDate = course.EndDate;
                c.ListOfStudents = course.ListOfStudents;
                return new NoContentResult();
            }
            return new NotFoundResult();
        }

        // DELETE api/courses/5
        [HttpDelete]
        [Route("{id}", Name = "DeleteCourseWithID")]
        public IActionResult DeleteCourseWithID(int id)
        {
            foreach (var c in _courses)
            {
                if (c.ID != id) continue;
                _courses.Remove(c);
                return new NoContentResult();
            }
            return new NotFoundResult();
        }

        // GET api/courses/{id}/students
        [HttpGet]
        [Route("{id}/students", Name = "GetStudentsInCourse")]
        public IActionResult GetStudentsInCourse(int id)
        {
            foreach (var c in _courses)
            {
                if (c.ID == id)
                {
                    return new ObjectResult(c.ListOfStudents);
                }
            }
            return new NotFoundResult();
        }

        // POST api/courses/{id}/students
        [HttpPost]
        [Route("{id}/students", Name = "AddStudentToCourse")]
        public IActionResult AddStudentToCourse(int id, [FromBody]Student student)
        {
            if (student == null)
            {
                return new BadRequestResult();
            }
            foreach (var c in _courses)
            {
                if (c.ID != id) continue;
                c.ListOfStudents.Add(student);
                var location = Url.Link("GetStudentsInCourse", new { id = c.ID });
                return new CreatedResult(location, c);
            }
            return new NotFoundResult();
        }
    }
}
