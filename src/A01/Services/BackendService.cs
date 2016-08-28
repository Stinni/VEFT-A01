using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using A01.Models;

namespace A01.Services
{
    public class BackendService
    {
        private int NextCourseId { get; set; }
        private List<Course> ListOfCourses { get; set; }
        private List<Student> ListOfStudents { get; set; }
        private StartupService _startupService;
        private static BackendService instance;

        public BackendService()
        {
            NextCourseId = 3;
            ListOfCourses = null;
            ListOfStudents = null;
            _startupService = new StartupService();
            instance = null;
        }

        private void Init()
        {
            NextCourseId = 3;
            ListOfCourses = null;
            ListOfStudents = null;
            _startupService = new StartupService();
        }

        public List<Course> GetAllCourses()
        {
            if (ListOfCourses != null) return ListOfCourses;
            ListOfCourses = _startupService.FillCoursesList();
            ListOfStudents = _startupService.FillStudentsList();

            return ListOfCourses;
        }

        public List<Student> GetAllStudents()
        {
            if (ListOfStudents != null) return ListOfStudents;
            ListOfCourses = _startupService.FillCoursesList();
            ListOfStudents = _startupService.FillStudentsList();

            return ListOfStudents;
        }

        public void AddCourse(Course c)
        {
            c.ID = NextCourseId;
            NextCourseId++;
            ListOfCourses.Add(c);
        }

        public void AddStudent(Student s)
        {
            ListOfStudents.Add(s);
        }
    }
}